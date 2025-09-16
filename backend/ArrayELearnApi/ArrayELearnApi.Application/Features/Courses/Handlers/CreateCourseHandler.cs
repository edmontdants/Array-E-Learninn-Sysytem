using ArrayELearnApi.Application.DTOs.Courses;
using ArrayELearnApi.Application.Features.Courses.Commands;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Handlers
{
    internal sealed class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        public Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
