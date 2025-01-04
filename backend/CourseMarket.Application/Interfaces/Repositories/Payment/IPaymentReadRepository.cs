namespace CourseMarket.Application.Interfaces.Repositories.Payment;

public interface IPaymentReadRepository : IReadRepository<Domain.Entities.Payment, Guid>
{
    Task<Domain.Entities.Payment> GetPaymentByOrderIdAsync(Guid orderId);
}