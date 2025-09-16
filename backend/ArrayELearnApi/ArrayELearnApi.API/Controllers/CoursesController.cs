using ArrayELearnApi.Application.DTOs;
using ArrayELearnApi.Application.Features.Courses.Commands;
using ArrayELearnApi.Application.Features.Courses.Queries;
using ArrayELearnApi.Domain.Entities.Domain;
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
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery(id));
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] CreateCourseCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseCommand request)
        {
            if (id != request.Id) return BadRequest();
            var result = await _mediator.Send(request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var command = new DeleteCourseCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsDeleted ? Ok( new DeleteResponse { Id = result.Id }) : NotFound();
        }
    }
}
