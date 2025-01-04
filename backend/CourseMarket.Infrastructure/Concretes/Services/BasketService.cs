using System.Net;
using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class BasketService(
    IHttpContextAccessor httpContextAccessor,
    IBasketReadRepository basketReadRepository,
    IBasketWriteRepository basketWriteRepository,
    ICourseReadRepository courseReadRepository,
    ICourseImageFileReadRepository courseImageFileReadRepository,
    IUnitOfWork unitOfWork
    ) : IBasketService
{
    public async Task<ServiceResult<List<BasketItemDto>>> GetBasketItemsAsync()
    {
        var userId = UserContext.GetUserId(httpContextAccessor);
        var basketCourseIdList = await basketReadRepository.GetCourseIdsByUserIdAsync(userId);

        if (basketCourseIdList.Count == 0)
        {
            return ServiceResult<List<BasketItemDto>>.SuccessAsOk([]);
        }

        var courses = await courseReadRepository.GetRange(basketCourseIdList);

        var courseImages = await courseImageFileReadRepository.GetAll()
            .Where(image => basketCourseIdList.Contains(image.CourseId))
            .ToDictionaryAsync(image => image.CourseId, image => image.Path);

        var basketItems = courses.Select(course => new BasketItemDto(
            course.Id,
            course.Name,
            course.Price,
            courseImages.GetValueOrDefault(course.Id, string.Empty)
        )).ToList();

        return ServiceResult<List<BasketItemDto>>.SuccessAsOk(basketItems);
    }

    public async Task<ServiceResult> AddCourseAsync(Guid courseId)
    {
        var userId = UserContext.GetUserId(httpContextAccessor);

        var exists = await basketReadRepository.ExistsAsync(userId, courseId);

        if (exists)
        {
            return ServiceResult.Error("Course already exists in the basket",
                $"The course with id({courseId}) already exists in the basket", HttpStatusCode.BadRequest);
        }

        var basket = new Basket(userId, courseId);

        await basketWriteRepository.AddAsync(basket);

        await unitOfWork.SaveChangesAsync();

        return ServiceResult.SuccessAsNoContent();

    }

    public async Task<ServiceResult> RemoveCourseAsync(Guid courseId)
    {
        var userId = UserContext.GetUserId(httpContextAccessor);

        var basketItem = await basketReadRepository.GetBasketItem(userId, courseId);

        if (basketItem is null)
        {
            return ServiceResult.Error("Course not found in the basket",
                $"The course with id({courseId}) was not found in the basket", HttpStatusCode.NotFound);
        }

        basketWriteRepository.Delete(basketItem);

        await unitOfWork.SaveChangesAsync();
        return ServiceResult.SuccessAsNoContent();
    }
}
