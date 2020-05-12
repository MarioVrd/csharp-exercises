using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages
{
    public class AddStudentBase : ComponentBase
    {
        [Inject]
        public IStudentiService StudentiService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Studenti student = new Studenti();
        protected async Task CreateStudent()
        {
            try
            {
                await StudentiService.AddStudent(student);
                NavigationManager.NavigateTo("/students");
            }
            catch (Exception)
            {
                // Display error
                // Log exception
            }
        }

    }
}
