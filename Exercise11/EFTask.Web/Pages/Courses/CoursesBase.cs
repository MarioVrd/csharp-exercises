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

        public List<Predmeti> Courses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Courses = await PredmetiService.GetCourses();
        }

        protected async Task DeleteCourse(int id)
        {
            await PredmetiService.DeleteCourse(id);
            Courses.RemoveAll(c => c.Id == id);
        }
    }
}
