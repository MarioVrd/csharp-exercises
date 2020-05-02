using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages
{
    public class CoursesBase : ComponentBase
    {
        [Inject]
        public IPredmetiService PredmetiService { get; set; }

        protected List<Predmeti> courses;

        protected override async Task OnInitializedAsync()
        {
            courses = await PredmetiService.GetCourses();
        }
    }
}
