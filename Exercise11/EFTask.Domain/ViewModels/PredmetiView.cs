using System;
using System.Collections.Generic;
using System.Text;

namespace EFTask.Domain.ViewModels
{
    public class PredmetiView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ICollection<PredmetiStudentiView> PredmetiStudenti { get; set; }
    }
}
