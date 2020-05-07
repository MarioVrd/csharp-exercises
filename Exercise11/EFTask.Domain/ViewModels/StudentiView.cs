using System;
using System.Collections.Generic;
using System.Text;

namespace EFTask.Domain.ViewModels
{
    public class StudentiView
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public ICollection<PredmetiStudentiView> PredmetiStudenti { get; set; }
    }
}
