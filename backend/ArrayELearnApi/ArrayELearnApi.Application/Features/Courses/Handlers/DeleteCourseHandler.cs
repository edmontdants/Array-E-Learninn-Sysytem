using ArrayELearnApi.Application.DTOs;
using ArrayELearnApi.Application.Features.Courses.Commands;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Handlers
{
    internal sealed class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, DeleteResponse>
    {
        public Task<DeleteResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
