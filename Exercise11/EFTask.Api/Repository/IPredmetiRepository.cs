using EFTask.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public interface IPredmetiRepository
    {
        Task<List<Predmeti>> GetCourses();
        Task<Predmeti> GetCourse(int courseId);
        Task<Predmeti> AddCourse(Predmeti course);
        Task<Predmeti> UpdateCourse(Predmeti updatedCourse);
        void DeleteCourse(int courseId);

    }
}
