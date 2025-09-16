using ArrayELearnApi.Application.DTOs.Courses;
using FluentValidation;

namespace ArrayELearnApi.Application.Validators.Courses
{
    internal class CreateCourseDtoValidator : AbstractValidator<CourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);
            
            RuleFor(x => x.Description)
                .MaximumLength(1000);
            
            RuleFor(x => x.InstructorId)
                .NotEmpty().WithMessage("Course should be assigned to an instructor");
        }
    }
}
