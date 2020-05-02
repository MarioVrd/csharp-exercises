using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTask.Api.Models;
using EFTask.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly StudentiContext _context;

        public EnrollmentController(StudentiContext context)
        {
            _context = context;
        }

        [HttpPut("{studentId}/{courseId}")]
        public async Task<ActionResult<Studenti>> AddEnrollment(int studentId, int courseId)
        {
            var student = await _context.Studenti.FirstOrDefaultAsync(s => s.Id == studentId);
            var course = await _context.Predmeti.FirstOrDefaultAsync(c => c.Id == courseId);

            if (student == null || course == null)
            {
                return NotFound();
            }

            PredmetiStudenti enrollment = new PredmetiStudenti
            {
                IdPredmeta = courseId,
                IdPredmetaNavigation = course,
                IdStudenta = studentId,
                IdStudentaNavigation = student
            };


            student.PredmetiStudenti.Add(enrollment);
            course.PredmetiStudenti.Add(enrollment);
            _context.PredmetiStudenti.Add(enrollment);

            return student;
        }
    }
}