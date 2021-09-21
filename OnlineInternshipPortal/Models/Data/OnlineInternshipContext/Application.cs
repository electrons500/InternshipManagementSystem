using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Application
    {
        public string ApplicationId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string InternId { get; set; }
        public string InternshipId { get; set; }
        public string CompanyId { get; set; }
        public int CvId { get; set; }
        public int ApprovalId { get; set; }

        public virtual InternshipApproval Approval { get; set; }
        public virtual Company Company { get; set; }
        public virtual Cv Cv { get; set; }
        public virtual Intern Intern { get; set; }
        public virtual Internship Internship { get; set; }
    }
}
