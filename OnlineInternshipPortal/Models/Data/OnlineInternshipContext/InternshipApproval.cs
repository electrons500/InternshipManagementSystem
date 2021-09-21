using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class InternshipApproval
    {
        public InternshipApproval()
        {
            Applications = new HashSet<Application>();
        }

        public int ApprovalId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
