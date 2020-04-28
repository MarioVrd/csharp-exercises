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
    public class StudentiController : ControllerBase
    {
        private readonly IStudentiRepository _studentiRepository;
        public StudentiController(IStudentiRepository studentiRepository)
        {
            _studentiRepository = studentiRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                var students = await _studentiRepository.GetStudentsWithCourses();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Studenti>> GetStudent(int id) 
        {
            try
            {
                var student = await _studentiRepository.GetStudentWithCourses(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Studenti>> CreateStudent(Studenti student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }

                var newStudent = await _studentiRepository.AddStudent(student);

                return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Studenti>> UpdateStudent(int id, Studenti updatedStudent)
        {
            try
            {
                if (id != updatedStudent.Id)
                {
                    return BadRequest("Student ID mismatch");
                }

                var studentToUpdate = await _studentiRepository.GetStudent(id);

                if (studentToUpdate == null)
                {
                    return NotFound("Student with specified ID not found");
                }

                return await _studentiRepository.UpdateStudent(updatedStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Studenti>> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await _studentiRepository.GetStudent(id);

                if (studentToDelete == null)
                {
                    return NotFound("Student with specified ID not found");
                }

                return await _studentiRepository.DeleteStudent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}