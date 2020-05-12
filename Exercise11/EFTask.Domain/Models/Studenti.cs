using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFTask.Domain.Models
{
    public partial class Studenti
    {
        public Studenti()
        {
            PredmetiStudenti = new HashSet<PredmetiStudenti>();
        }

        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }

        public virtual ICollection<PredmetiStudenti> PredmetiStudenti { get; set; }
    }
}
