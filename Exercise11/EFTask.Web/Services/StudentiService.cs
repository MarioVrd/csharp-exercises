using EFTask.Domain.Models;
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
    }
}
