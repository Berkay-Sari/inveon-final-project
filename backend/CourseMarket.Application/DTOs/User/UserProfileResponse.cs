namespace CourseMarket.Application.DTOs.User;

public record UserProfileResponse(string FullName, string Email, string PhoneNumber, string PurchasedCourses);