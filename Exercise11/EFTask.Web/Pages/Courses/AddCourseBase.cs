using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages.Courses
{
    public class AddCourseBase : ComponentBase
    {
        [Inject]
        IPredmetiService PredmetiService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public Predmeti Course { get; set; } = new Predmeti();

        public async Task AddCourse()
        {
            var response = await PredmetiService.AddCourse(Course);

            if (response != null)
            {
                NavigationManager.NavigateTo("/courses");
            }
        }
    }
}
