using EFTask.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public class PredmetiRepository : IPredmetiRepository
    {
        private readonly StudentiContext _context;

        public PredmetiRepository(StudentiContext context)
        {
            _context = context;
        }

        public async Task<Predmeti> AddCourse(Predmeti course)
        {
            var result = await _context.Predmeti.AddAsync(course);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeleteCourse(int courseId)
        {
            var course = await _context.Predmeti.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course != null)
            {
                _context.Predmeti.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Predmeti> GetCourse(int courseId)
        {
            return await _context.Predmeti.FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<List<Predmeti>> GetCourses()
        {
            return await _context.Predmeti.ToListAsync();
        }

        public async Task<Predmeti> UpdateCourse(Predmeti updatedCourse)
        {
            var course = await _context.Predmeti.FirstOrDefaultAsync(c => c.Id == updatedCourse.Id);

            if (course != null)
            {
                course.Naziv = updatedCourse.Naziv;

                await _context.SaveChangesAsync();
                return course;
            }

            return null;
        }
    }
}
