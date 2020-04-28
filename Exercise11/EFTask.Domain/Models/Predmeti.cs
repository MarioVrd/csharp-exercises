using System;
using System.Collections.Generic;

namespace EFTask.Domain.Models
{
    public partial class Predmeti
    {
        public Predmeti()
        {
            PredmetiStudenti = new HashSet<PredmetiStudenti>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<PredmetiStudenti> PredmetiStudenti { get; set; }
    }
}
