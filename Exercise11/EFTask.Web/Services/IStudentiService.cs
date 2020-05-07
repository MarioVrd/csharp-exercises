using EFTask.Domain.Models;
using EFTask.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Services
{
    public interface IStudentiService
    {
        Task<List<Studenti>> GetStudents();
        Task<Studenti> GetStudent(int id);
        Task<StudentiView> GetStudentView(int id);
        Task<Studenti> AddStudent(Studenti student);
        Task<Studenti> UpdateStudent(int id, StudentiView student);
        Task DeleteStudent(int id);
    }
}
