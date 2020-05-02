using EFTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public interface IPredmetiRepository
    {
        Task<List<Predmeti>> GetCourses();
        Task<List<Predmeti>> GetCoursesWithStudents();
        Task<Predmeti> GetCourse(int courseId);
        Task<Predmeti> GetCourseWithStudents(int courseId);
        Task<Predmeti> AddCourse(Predmeti course);
        Task<Predmeti> UpdateCourse(Predmeti updatedCourse);
        Task DeleteCourse(int courseId);

    }
}
