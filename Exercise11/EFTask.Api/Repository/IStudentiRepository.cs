using EFTask.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Api.Repository
{
    public interface IStudentiRepository
    {
        Task<List<Studenti>> GetStudents();
        Task<Studenti> GetStudent(int studentId);
        Task<Studenti> AddStudent(Studenti student);
        Task<Studenti> UpdateStudent(Studenti updatedStudent);
        void DeleteStudent(int studentId);
    }
}
