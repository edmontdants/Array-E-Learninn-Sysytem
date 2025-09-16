using ArrayELearnApi.Application.DTOs.Courses;
using ArrayELearnApi.Application.Features.Courses.Commands;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Handlers
{
    internal sealed class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, CourseDto>
    {
        public Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
