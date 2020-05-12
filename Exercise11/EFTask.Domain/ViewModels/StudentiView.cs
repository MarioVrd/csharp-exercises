using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFTask.Domain.ViewModels
{
    public class StudentiView
    {
        public StudentiView()
        {
            PredmetiStudenti = new HashSet<PredmetiStudentiView>();
        }
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public ICollection<PredmetiStudentiView> PredmetiStudenti { get; set; }
    }
}
