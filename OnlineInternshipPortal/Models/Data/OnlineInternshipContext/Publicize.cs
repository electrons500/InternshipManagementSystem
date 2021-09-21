using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Publicize
    {
        public Publicize()
        {
            Internships = new HashSet<Internship>();
        }

        public int PublicizeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Internship> Internships { get; set; }
    }
}
