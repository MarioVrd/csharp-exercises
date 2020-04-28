﻿using EFTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTask.Web.Services
{
    public interface IStudentiService
    {
        Task<List<Studenti>> GetStudents();
    }
}
