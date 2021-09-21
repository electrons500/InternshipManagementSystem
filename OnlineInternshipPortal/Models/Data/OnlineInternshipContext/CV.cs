using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Cv
    {
        public Cv()
        {
            Applications = new HashSet<Application>();
            Interns = new HashSet<Intern>();
        }

        public int CvId { get; set; }
        public string Filename { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Intern> Interns { get; set; }
    }
}
