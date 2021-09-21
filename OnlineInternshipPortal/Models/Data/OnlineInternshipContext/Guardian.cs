using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Guardian
    {
        public Guardian()
        {
            Interns = new HashSet<Intern>();
        }

        public int GuardianId { get; set; }
        public string GuardianName { get; set; }
        public string ContactNumber { get; set; }
        public string Residence { get; set; }
        public int GuardianCategoryId { get; set; }

        public virtual GuardianCategory GuardianCategory { get; set; }
        public virtual ICollection<Intern> Interns { get; set; }
    }
}
