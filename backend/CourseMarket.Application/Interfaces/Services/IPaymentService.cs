using CourseMarket.Application.Wrappers;

namespace CourseMarket.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<ServiceResult<string>> PayAsync(bool isSuccess);
}
