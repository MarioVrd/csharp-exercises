using EFTask.Domain.Models;
using EFTask.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Pages
{
    public class StudentsBase : ComponentBase
    {
        [Inject]
        public IStudentiService StudentiService { get; set; }

        protected List<Studenti> students;

        protected override async Task OnInitializedAsync()
        {
            students = await StudentiService.GetStudents();
        }
    }
}
