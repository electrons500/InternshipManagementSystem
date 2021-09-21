using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Industry
    {
        public Industry()
        {
            Companies = new HashSet<Company>();
            Internships = new HashSet<Internship>();
        }

        public int IndustryId { get; set; }
        public string IndustryName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Internship> Internships { get; set; }
    }
}
