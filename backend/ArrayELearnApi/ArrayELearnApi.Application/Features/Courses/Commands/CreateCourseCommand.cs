using ArrayELearnApi.Application.DTOs.Courses;
using MediatR;

namespace ArrayELearnApi.Application.Features.Courses.Commands
{
    public class CreateCourseCommand : IRequest<CourseDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorId { get; set; }
    }
}
