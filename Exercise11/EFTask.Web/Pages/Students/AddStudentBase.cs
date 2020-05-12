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

        public Studenti Student { get; set; } = new Studenti();
        protected async Task CreateStudent()
        {
            try
            {
                var response = await StudentiService.AddStudent(Student);
                if (response != null)
                {
                    NavigationManager.NavigateTo("/students");
                }
            }
            catch (Exception)
            {
                // Display error
                // Log exception
            }
        }

    }
}
