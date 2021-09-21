using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class School
    {
        public School()
        {
            Interns = new HashSet<Intern>();
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        public virtual ICollection<Intern> Interns { get; set; }
    }
}
