using System.Net;
using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Application.Interfaces.Repositories.Payment;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class PaymentService(
    IPaymentWriteRepository paymentWriteRepository,
    IPaymentReadRepository paymentReadRepository,
    IOrderReadRepository orderReadRepository,
    IHttpContextAccessor httpContextAccessor,
    IBasketWriteRepository basketWriteRepository,
    IOrderService orderService,
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork
    ) : IPaymentService
{
    public async Task<ServiceResult<string>> PayAsync(bool isSuccess)
    {
        var userId = UserContext.GetUserId(httpContextAccessor);

        var order = await orderReadRepository.GetUncompletedOrderByUserIdAsync(userId);

        var payment = await paymentReadRepository.GetPaymentByOrderIdAsync(order!.Id);

        ServiceResult<string> result;
        if (isSuccess)
        {
            payment.SetSuccessStatus();
            payment.Error = null;
            var orderCode = orderService.CompleteOrder(order);
            basketWriteRepository.DeleteByUserId(userId);
            var user = await userManager.FindByIdAsync(userId.ToString());
            user!.AddCourseIds(order.GetCourseIds());
            result = ServiceResult<string>.SuccessAsOk(orderCode);
        }
        else
        {
            payment.SetFailStatus("Incorrect payment info");
            result = ServiceResult<string>.Error("Payment Error","Incorrect payment info", HttpStatusCode.BadRequest);
        }

        paymentWriteRepository.Update(payment);
        await unitOfWork.SaveChangesAsync();
        return result;
    }
}


