using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Region
    {
        public Region()
        {
            Companies = new HashSet<Company>();
            Interns = new HashSet<Intern>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Intern> Interns { get; set; }
    }
}
