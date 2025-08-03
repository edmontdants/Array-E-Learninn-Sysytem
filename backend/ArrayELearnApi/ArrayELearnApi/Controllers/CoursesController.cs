using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArrayELearnApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery(id));
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course updated)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
