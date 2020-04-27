using EFTask.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public interface IStudentiRepository
    {
        Task<Studenti> AddStudent(Studenti student);
        Task<Studenti> DeleteStudent(int studentId);
        Task<Studenti> GetStudent(int studentId);
        Task<Studenti> GetStudentWithCourses(int studentId);
        Task<List<Studenti>> GetStudents();
        Task<List<Studenti>> GetStudentsWithCourses();
        Task<Studenti> UpdateStudent(Studenti updatedStudent);
    }
}
