using CourseMarket.Application.Interfaces.Repositories.Payment;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Payment;

public class PaymentWriteRepository(AppDbContext context)
    : WriteRepository<Domain.Entities.Payment, Guid>(context), IPaymentWriteRepository;