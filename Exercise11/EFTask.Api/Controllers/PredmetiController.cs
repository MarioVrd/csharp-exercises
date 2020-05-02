using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTask.Api.Repository;
using EFTask.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetiController : ControllerBase
    {
        private readonly IPredmetiRepository _predmetiRepository;

        public PredmetiController(IPredmetiRepository predmetiRepository)
        {
            _predmetiRepository = predmetiRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Predmeti>>> GetCourses()
        {
            return Ok(await _predmetiRepository.GetCoursesWithStudents());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Predmeti>> GetCourse(int id)
        {
            try
            {
                var course = await _predmetiRepository.GetCourse(id);

                if (course == null)
                {
                    return NotFound();
                }

                return Ok(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Predmeti>> CreateCourse(Predmeti course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest();
                }

                var newCourse = await _predmetiRepository.AddCourse(course);

                return CreatedAtAction(nameof(GetCourse), new { id = newCourse.Id }, newCourse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Predmeti>> UpdateCourse(int id, Predmeti updatedCourse)
        {
            try
            {
                if (id != updatedCourse.Id)
                {
                    return BadRequest("Course ID mismatch");
                }

                var courseToUpdate = await _predmetiRepository.GetCourse(id);

                if (courseToUpdate == null)
                {
                    return NotFound("Course with specified ID not found");
                }

                return await _predmetiRepository.UpdateCourse(updatedCourse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            try
            {
                var course = await _predmetiRepository.GetCourse(id);

                if (course == null)
                {
                    return NotFound("Course with specified ID not found");
                }

                await _predmetiRepository.DeleteCourse(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}