using EFTask.Domain.Models;
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
    }
}
