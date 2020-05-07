using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFTask.Domain.Models
{
    public partial class Predmeti
    {
        public Predmeti()
        {
            PredmetiStudenti = new HashSet<PredmetiStudenti>();
        }

        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }

        public virtual ICollection<PredmetiStudenti> PredmetiStudenti { get; set; }
    }
}
