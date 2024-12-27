using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Repositories;

public class PaymentRepository(AppDbContext context) : GenericRepository<Payment, Guid>(context), IPaymentRepository
{
}