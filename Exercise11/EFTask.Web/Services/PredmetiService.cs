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
    public class PredmetiService : IPredmetiService
    {
        private readonly HttpClient _httpClient;

        public PredmetiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Predmeti>> GetCourses()
        {
            return await _httpClient.GetJsonAsync<List<Predmeti>>("api/predmeti");
        }

        public async Task<List<PredmetiView>> GetCoursesView()
        {
            var courses = await _httpClient.GetJsonAsync<List<Predmeti>>("api/predmeti");

            List<PredmetiView> output = new List<PredmetiView>();

            courses.ForEach(course =>
            {
                var courseView = new PredmetiView { Id = course.Id, Naziv = course.Naziv, PredmetiStudenti = new HashSet<PredmetiStudentiView>() };

                foreach (var e in course.PredmetiStudenti)
                {
                    PredmetiStudentiView enrView = new PredmetiStudentiView { IdPredmeta = e.IdPredmeta, IdStudenta = e.IdStudenta };
                    courseView.PredmetiStudenti.Add(enrView);
                }
                
                output.Add(courseView);
            });

            return output;
        }

        public async Task<Predmeti> GetCourse(int id)
        {
            return await _httpClient.GetJsonAsync<Predmeti>($"api/predmeti/{id}");
        }

        public async Task<Predmeti> AddCourse(Predmeti course)
        {
            return await _httpClient.PostJsonAsync<Predmeti>("api/predmeti", course);
        }

        public async Task<Predmeti> UpdateCourse(int id, Predmeti course)
        {
            return await _httpClient.PutJsonAsync<Predmeti>($"api/predmeti/{id}", course);
        }

        public async Task DeleteCourse(int id)
        {
            await _httpClient.DeleteAsync($"api/predmeti/{id}");
        }
    }
}
