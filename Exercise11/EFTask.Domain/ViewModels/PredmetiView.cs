using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFTask.Domain.ViewModels
{
    public class PredmetiView
    {
        public PredmetiView()
        {
            PredmetiStudenti = new HashSet<PredmetiStudentiView>();
        }
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public ICollection<PredmetiStudentiView> PredmetiStudenti { get; set; }
    }
}
