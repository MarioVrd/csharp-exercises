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

        protected override async Task OnInitializedAsync()
        {
            Student = await StudentiService.GetStudent(Id);
        }
    }
}
