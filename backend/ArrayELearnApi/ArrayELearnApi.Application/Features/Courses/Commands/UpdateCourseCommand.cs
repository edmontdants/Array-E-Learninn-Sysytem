using ArrayELearnApi.Application.DTOs.Courses;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Commands
{
    public class UpdateCourseCommand : CourseDto, IRequest<CourseDto>
    {
    }
}
