
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using Repositories;
using Models;

namespace Learning_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repository.GetAllCourses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(string id)
        {
            var course = await _repository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            await _repository.CreateCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateCourse(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var courseToDelete = await _repository.GetCourseById(id);
            if (courseToDelete == null)
            {
                return NotFound();
            }
            await _repository.DeleteCourse(id);
            return NoContent();
        }
    }
}