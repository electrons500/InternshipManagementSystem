using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Internship
    {
        public Internship()
        {
            Applications = new HashSet<Application>();
        }

        public string InternshipId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }
        public string WorkDescription { get; set; }
        public string SkillsRequired { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime DeadLineDate { get; set; }
        public string WhoCanApply { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostedTime { get; set; }
        public int InternshipStatusId { get; set; }
        public int RemoteId { get; set; }
        public int? CompanyImageId { get; set; }
        public int PublicizeId { get; set; }
        public int IndustryId { get; set; }
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; } 
        public virtual CompanyLogo CompanyImage { get; set; }
        public virtual Industry Industry { get; set; }
        public virtual InternshipStatus InternshipStatus { get; set; }
        public virtual Publicize Publicize { get; set; }
        public virtual Remote Remote { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
