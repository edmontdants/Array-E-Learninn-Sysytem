using ArrayELearnApi.Application.DTOs;
using ArrayELearnApi.Application.DTOs.Courses;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : CourseDto, IRequest<DeleteResponse>
    {
    }
}
