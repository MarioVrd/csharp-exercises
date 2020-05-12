using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages.Students
{
    public class StudentDetailsBase : ComponentBase
    {
        [Inject]
        IStudentiService StudentiService { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Studenti Student { get; set; }
        public bool FetchSuccess { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Student = await StudentiService.GetStudent(Id);
                FetchSuccess = true;
            }
            catch (Exception)
            {
                FetchSuccess = false;
            }
        }
    }
}
