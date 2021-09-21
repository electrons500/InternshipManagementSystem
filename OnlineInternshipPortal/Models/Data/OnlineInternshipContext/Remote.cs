using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Remote
    {
        public Remote()
        {
            Internships = new HashSet<Internship>();
        }

        public int RemoteId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Internship> Internships { get; set; }
    }
}
