using System;
using System.Collections.Generic;

namespace EFTask.Api.Models
{
    public partial class PredmetiStudenti
    {
        public int IdPredmeta { get; set; }
        public int IdStudenta { get; set; }

        public virtual Predmeti IdPredmetaNavigation { get; set; }
        public virtual Studenti IdStudentaNavigation { get; set; }
    }
}
