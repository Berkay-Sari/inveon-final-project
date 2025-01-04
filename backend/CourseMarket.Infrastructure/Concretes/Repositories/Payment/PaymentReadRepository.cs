using CourseMarket.Application.Interfaces.Repositories.Payment;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Payment;

public class PaymentReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Payment, Guid>(context), IPaymentReadRepository
{
    public Task<Domain.Entities.Payment> GetPaymentByOrderIdAsync(Guid orderId)
    {
        return Table
            .Where(payment => payment.OrderId == orderId).FirstOrDefaultAsync()!;
    }
}