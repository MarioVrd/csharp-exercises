using System;
using System.Collections.Generic;

namespace EFTask.Api.Models
{
    public partial class Studenti
    {
        public Studenti()
        {
            PredmetiStudenti = new HashSet<PredmetiStudenti>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public virtual ICollection<PredmetiStudenti> PredmetiStudenti { get; set; }
    }
}
