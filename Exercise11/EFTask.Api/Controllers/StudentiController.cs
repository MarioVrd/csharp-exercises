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
        private readonly IPredmetiRepository _predmetiRepository;

        public StudentiController(IStudentiRepository studentiRepository, IPredmetiRepository predmetiRepository)
        {
            _studentiRepository = studentiRepository;
            _predmetiRepository = predmetiRepository;
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

        [HttpPut("{studentId:int}/enroll/{courseId:int}")]
        public async Task<ActionResult<Studenti>> EnrollStudent(int studentId, int courseId)
        {
            try
            {
                var studentToUpdate = await _studentiRepository.GetStudentWithCourses(studentId);
                var course = await _predmetiRepository.GetCourse(courseId);

                if (studentToUpdate == null || course == null)
                {
                    return NotFound("Requested data couldn't be found.");
                }

                PredmetiStudenti enrollment = new PredmetiStudenti {
                    IdPredmeta = course.Id,
                    IdPredmetaNavigation = course,
                    IdStudenta = studentToUpdate.Id,
                    IdStudentaNavigation = studentToUpdate
                };

                studentToUpdate.PredmetiStudenti.Add(enrollment);
                course.PredmetiStudenti.Add(enrollment);

                return await _studentiRepository.UpdateStudent(studentToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPut("{studentId:int}/unenroll/{courseId:int}")]
        public async Task<ActionResult<Studenti>> UnenrollStudent(int studentId, int courseId)
        {
            try
            {
                var studentToUpdate = await _studentiRepository.GetStudentWithCourses(studentId);
                var course = await _predmetiRepository.GetCourse(courseId);

                if (studentToUpdate == null || course == null)
                {
                    return NotFound("Requested data couldn't be found.");
                }

                var enrollment = studentToUpdate.PredmetiStudenti.FirstOrDefault(e => e.IdPredmeta == courseId);

                studentToUpdate.PredmetiStudenti.Remove(enrollment);
                course.PredmetiStudenti.Remove(enrollment);

                return await _studentiRepository.UpdateStudent(studentToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await _studentiRepository.GetStudent(id);

                if (studentToDelete == null)
                {
                    return NotFound("Student with specified ID not found");
                }

                await _studentiRepository.DeleteStudent(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}