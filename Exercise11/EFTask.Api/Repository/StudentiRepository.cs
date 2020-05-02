using EFTask.Domain.Models;
using EFTask.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public class StudentiRepository : IStudentiRepository
    {
        private readonly StudentiContext _context;

        public StudentiRepository(StudentiContext context)
        {
            _context = context;
        }
        
        public async Task<Studenti> AddStudent(Studenti student)
        {
            var result = await _context.Studenti.AddAsync(student);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        /// <summary>
        /// Delete student and all enrollments
        /// </summary>
        /// <param name="studentId">ID of student to delete</param>
        /// <returns>Removed student</returns>
        public async Task DeleteStudent(int studentId)
        {
            var student = await _context.Studenti.FirstOrDefaultAsync(s => s.Id == studentId);

            if (student != null)
            {
                // Find and Remove connections
                var enrollmentsToRemove = _context.PredmetiStudenti.Where(e => e.IdStudenta == student.Id);
                _context.PredmetiStudenti.RemoveRange(enrollmentsToRemove);

                // Remove student
                _context.Studenti.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Studenti> GetStudent(int studentId)
        {
            return await _context.Studenti.FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<List<Studenti>> GetStudents()
        {
            return await _context.Studenti.ToListAsync();
        }

        public async Task<Studenti> GetStudentWithCourses(int studentId)
        {
            var student = await _context.Studenti
                                .Where(s => s.Id == studentId)
                                .Include(e => e.PredmetiStudenti)
                                .ThenInclude(c => c.IdPredmetaNavigation)
                                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<List<Studenti>> GetStudentsWithCourses()
        {
            var students = await _context.Studenti
                                    .Include(e => e.PredmetiStudenti)
                                    .ThenInclude(c => c.IdPredmetaNavigation)
                                    .ToListAsync();

            return students;
        }

        public async Task<Studenti> UpdateStudent(Studenti updatedStudent)
        {
            var student = await _context.Studenti.FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);

            if (student != null)
            {
                student.Ime = updatedStudent.Ime;
                student.Prezime = updatedStudent.Prezime;

                if (student.PredmetiStudenti.Count != updatedStudent.PredmetiStudenti.Count)
                {
                    student.PredmetiStudenti.Clear();
                    student.PredmetiStudenti = updatedStudent.PredmetiStudenti;
                }

                await _context.SaveChangesAsync();

                return student;
            }

            return null;
        }
    }
}
