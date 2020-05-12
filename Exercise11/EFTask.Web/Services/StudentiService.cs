using EFTask.Domain.Models;
using EFTask.Domain.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EFTask.Web.Services
{
    public class StudentiService : IStudentiService
    {
        private readonly HttpClient _httpClient;

        public StudentiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Studenti>> GetStudents()
        {
            return await _httpClient.GetJsonAsync<List<Studenti>>("api/studenti");
        }

        public async Task<Studenti> GetStudent(int id)
        {
            return await _httpClient.GetJsonAsync<Studenti>($"api/studenti/{ id }");
        }

        public async Task<StudentiView> GetStudentView(int id)
        {
            var student = await _httpClient.GetJsonAsync<Studenti>($"api/studenti/{ id }");

            #region Mapping Student to StudentView
            StudentiView output = new StudentiView { Id = student.Id, Ime = student.Ime, Prezime = student.Prezime };

            foreach (var e in student.PredmetiStudenti)
            {
                var enrView = new PredmetiStudentiView { IdPredmeta = e.IdPredmeta, IdStudenta = e.IdStudenta };
                output.PredmetiStudenti.Add(enrView);
            }
            #endregion

            return output;
        }

        public async Task<Studenti> AddStudent(Studenti student)
        {
            return await _httpClient.PostJsonAsync<Studenti>("api/studenti", student);
        }

        public async Task<Studenti> UpdateStudent(int id, StudentiView student)
        {
            #region Mapping StudentiView to Studenti
            Studenti parsedStudent = new Studenti 
            { 
                Id = student.Id,
                Ime = student.Ime,
                Prezime = student.Prezime,
            };

            foreach (var e in student.PredmetiStudenti)
            {
                PredmetiStudenti enrollment = new PredmetiStudenti { IdPredmeta = e.IdPredmeta, IdStudenta = e.IdStudenta };
                parsedStudent.PredmetiStudenti.Add(enrollment);
            }

            #endregion

            var response = await _httpClient.PutJsonAsync<Studenti>($"api/studenti/{ id }", parsedStudent);
            return response;
        }

        public async Task DeleteStudent(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/studenti/{ id }");
        }
    }
}
