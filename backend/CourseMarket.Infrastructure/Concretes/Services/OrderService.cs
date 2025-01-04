﻿using System.Net;
using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.DTOs.Order;
using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Application.Interfaces.Repositories.Payment;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class OrderService(
    IHttpContextAccessor httpContextAccessor,
    IOrderReadRepository orderReadRepository,
    IOrderWriteRepository orderWriteRepository,
    IBasketReadRepository basketReadRepository,
    IPaymentWriteRepository paymentWriteRepository,
    IPaymentReadRepository paymentReadRepository,
    IUnitOfWork unitOfWork
    ) : IOrderService
{
    public async Task<ServiceResult> UpsertOrderAsync(decimal totalAmount)
    {
        var userId = UserContext.GetUserId(httpContextAccessor);
        var basketItems = await basketReadRepository.GetCourseIdsByUserIdAsync(userId);
        var order = await orderReadRepository.GetUncompletedOrderByUserIdAsync(userId);

        if (order == null)
        {
            order = new Order(userId, basketItems, totalAmount);
            await orderWriteRepository.AddAsync(order);
            await unitOfWork.SaveChangesAsync();
            var payment = new Payment(userId, order.Id, totalAmount);
            await paymentWriteRepository.AddAsync(payment);
        }
        else
        {
            order.UpdateCourseIds(basketItems);
            order.TotalAmount = totalAmount;
            var payment = await paymentReadRepository.GetPaymentByOrderIdAsync(order.Id);
            payment!.Amount = totalAmount;
            orderWriteRepository.Update(order);
        }

        await unitOfWork.SaveChangesAsync();

        return ServiceResult.SuccessAsNoContent();
    }

    public string CompleteOrder(Order order)
    {
        var orderCode = (new Random().NextDouble() * 10000).ToString();
        orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);
        order.CompleteOrder(orderCode);
        orderWriteRepository.Update(order);
        return orderCode;
    }
}