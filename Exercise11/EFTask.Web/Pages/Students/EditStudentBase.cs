using EFTask.Domain.ViewModels;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages.Students
{
    public class EditStudentBase : ComponentBase
    {
        [Inject]
        public IStudentiService StudentiService { get; set; }
        [Inject]
        public IPredmetiService PredmetiService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }
        public StudentiView Student { get; set; }
        public bool FetchSuccess { get; set; } = true;
        public List<PredmetiView> Courses { get; set; }

        protected override async Task OnInitializedAsync()
        {

            try
            {
                Student = await StudentiService.GetStudentView(Id);
                Courses = await PredmetiService.GetCoursesView();
                FetchSuccess = true;
            }
            catch (Exception)
            {
                FetchSuccess = false;
            }
        }

        protected void EnrollCourse(PredmetiView course)
        {
            PredmetiStudentiView enrollment = new PredmetiStudentiView
            {
                IdStudenta = Student.Id,
                IdPredmeta = course.Id
            };

            Student.PredmetiStudenti.Add(enrollment);
        }

        protected async Task UpdateStudent()
        {
            var response = await StudentiService.UpdateStudent(Id, Student);
            if (response != null)
            {
                NavigationManager.NavigateTo($"/students/{Id}/details"); 
            }
        }
    }
}
