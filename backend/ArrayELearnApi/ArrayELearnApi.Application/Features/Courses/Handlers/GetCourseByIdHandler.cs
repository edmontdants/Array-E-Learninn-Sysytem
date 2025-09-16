using ArrayELearnApi.Application.DTOs.Courses;
using ArrayELearnApi.Application.Features.Courses.Queries;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Handlers
{
    internal sealed class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
    {
        public Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
