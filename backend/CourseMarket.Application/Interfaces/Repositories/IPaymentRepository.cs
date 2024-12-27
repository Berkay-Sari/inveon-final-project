using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Repositories;

public interface IPaymentRepository : IRepository<Payment, Guid>
{
}