using CourseMarket.Application.DTOs.Course;
using FluentValidation;

namespace CourseMarket.Application.Validators.Courses;

public class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull().WithMessage("Please provide a name for the course.")
            .MaximumLength(100)
            .MinimumLength(5).WithMessage("The course name must be between 5 and 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("The course description must be less than 500 characters.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The course price must be greater than 0.");
        RuleFor(x => x.Category)
            .NotEmpty()
            .NotNull().WithMessage("Please provide a category for the course.")
            .MaximumLength(50)
            .MinimumLength(5).WithMessage("The course category must be between 5 and 50 characters.");
    }
}
