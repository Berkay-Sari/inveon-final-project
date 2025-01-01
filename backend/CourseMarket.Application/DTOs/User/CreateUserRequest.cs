namespace CourseMarket.Application.DTOs.User;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string PasswordConfirm
);
