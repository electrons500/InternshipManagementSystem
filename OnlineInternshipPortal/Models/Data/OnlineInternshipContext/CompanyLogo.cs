using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class CompanyLogo
    {
        public CompanyLogo()
        {
            Companies = new HashSet<Company>();
            Internships = new HashSet<Internship>();
        }

        public int CompanyImageId { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Internship> Internships { get; set; }
    }
}
