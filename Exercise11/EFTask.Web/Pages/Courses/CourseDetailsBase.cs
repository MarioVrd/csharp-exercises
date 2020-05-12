using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EFTask.Web.Pages.Courses
{
    public class CourseDetailsBase : ComponentBase
    {
        [Inject]
        public IPredmetiService PredmetiService { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Predmeti Course { get; set; }
        public bool FetchSuccess { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Course = await PredmetiService.GetCourse(Id);
                FetchSuccess = true;
            }
            catch (Exception)
            {
                FetchSuccess = false;
            }
        }

    }
}
