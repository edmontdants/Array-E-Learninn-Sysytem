using ArrayELearnApi.Application.DTOs.Courses;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Queries
{
    public class GetCourseByIdQuery(int Id) : CourseDto, IRequest<CourseDto>
    {

    }
}
