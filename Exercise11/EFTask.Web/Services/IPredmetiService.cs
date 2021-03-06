﻿using EFTask.Domain.Models;
using EFTask.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Services
{
    public interface IPredmetiService
    {
        Task<List<Predmeti>> GetCourses();
        Task<List<PredmetiView>> GetCoursesView();
        Task<Predmeti> GetCourse(int id);
        Task<Predmeti> AddCourse(Predmeti course);
        Task<Predmeti> UpdateCourse(int id, Predmeti course);
        Task DeleteCourse(int id);
    }
}
