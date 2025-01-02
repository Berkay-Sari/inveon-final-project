using System.Net;
using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Application.Interfaces.Repositories.BasketItem;
using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Concretes.Repositories.BasketItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class BasketService(
    IHttpContextAccessor httpContextAccessor,
    UserManager<AppUser> userManager,
    IOrderReadRepository orderReadRepository,
    IBasketItemWriteRepository basketItemWriteRepository,
    IBasketItemReadRepository basketItemReadRepository,
    IBasketReadRepository basketReadRepository,
    IUnitOfWork unitOfWork
    ) : IBasketService
{
    public async Task<ServiceResult<List<BasketItemDto>>> GetBasketItemsAsync()
    {
        var basket = await ContextUser();
        var result = await basketReadRepository.Table
            .Include(b => b.Items)
            .ThenInclude(bi => bi.Course)
            .FirstOrDefaultAsync(b => b.Id == basket!.Id);

        if (result is null)
        {
            return ServiceResult<List<BasketItemDto>>.Error(new ProblemDetails
            {
                Title = "Basket not found",
                Detail = "Basket not found",
                Status = (int)HttpStatusCode.NotFound
            }, HttpStatusCode.NotFound);
        }

        var basketItems = result.Items.Select(bi => new BasketItemDto(
            CourseName: bi.Course.Name,
            ImageUrl: bi.Course.Image.Path,
            Price: bi.Course.Price,
            CourseId: bi.CourseId,
            BasketItemId: bi.Id
        ));

        return ServiceResult<List<BasketItemDto>>.SuccessAsOk(basketItems.ToList());
    }

    public async Task<ServiceResult> AddItemToBasketAsync(Guid courseId)
    {
        var basket = await ContextUser();
        if (basket == null)
        {
            return ServiceResult<BasketItemDto>.Error(new ProblemDetails
            {
                Title = "Basket not found",
                Detail = "Basket not found",
                Status = (int)HttpStatusCode.NotFound
            }, HttpStatusCode.NotFound);
        }
        
        var basketId = basket.Id;
        var basketItem = await basketItemReadRepository.GetSingleAsync(
            bi => bi.BasketId == basketId && bi.CourseId == courseId, 
            true);
        if (basketItem != null)
        {
            return ServiceResult.Error(new ProblemDetails
            {
                Title = "Item already exist",
                Detail = "Course already exists in basket",
                Status = (int)HttpStatusCode.BadRequest
            }, HttpStatusCode.BadRequest);
        }
        
        await basketItemWriteRepository.AddAsync(new BasketItem
        {
            BasketId = basketId,
            CourseId = courseId
        });

        await unitOfWork.SaveChangesAsync();

        return ServiceResult.SuccessAsNoContent();

    }

    public async Task<ServiceResult> RemoveItemFromBasketAsync(Guid basketItemId)
    {
        var basketItem = await basketItemReadRepository.GetByIdAsync(basketItemId, true);
        if (basketItem == null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        basketItemWriteRepository.Delete(basketItem);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task<Basket?> ContextUser()
    {
        var username = httpContextAccessor?.HttpContext?.User?.Identity?.Name;
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("User not found");
        }

        var user = await userManager.Users
            .Include(u => u.Baskets)
            .FirstOrDefaultAsync(u => u.UserName == username);

        var _basket = (from basket in user!.Baskets 
            join order in orderReadRepository.Table 
                on basket.Id equals order.Id into BasketOrders 
            from order in BasketOrders.DefaultIfEmpty() 
            select new 
            { 
                Basket = basket, 
                Order = order
            }).ToList();

        Basket? targetBasket;
        if (_basket.Any(b => b.Order is null))
            targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
        else
        {
            targetBasket = new Basket();
            user.Baskets.Add(targetBasket);
        }

        await unitOfWork.SaveChangesAsync();
        return targetBasket;
    }

    public Basket? GetUserActiveBasket
    {
        get
        {
            var basket = ContextUser().Result;
            return basket;
        }
    }
}
