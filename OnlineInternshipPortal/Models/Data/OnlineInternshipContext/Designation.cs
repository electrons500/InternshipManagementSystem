using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Designation
    {
        public Designation()
        {
            Companies = new HashSet<Company>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
