namespace CourseMarket.Application.DTOs.User;

public record LoginRequest(
    string UserName,
    string Password,
    bool RememberMe
);


