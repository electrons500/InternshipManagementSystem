using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Company
    {
        public Company()
        {
            Applications = new HashSet<Application>();
            Hireds = new HashSet<Hired>();
            RecievedMsgFromCompanies = new HashSet<RecievedMsgFromCompany>();
            SentMsgToHiredInterns = new HashSet<SentMsgToHiredIntern>();
            VerifyCompanies = new HashSet<VerifyCompany>();
        }

        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyRegNo { get; set; }
        public string CompanyDescription { get; set; }
        public string Companywebsite { get; set; }
        public string CompanyVideoLink { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyEmail { get; set; }
        public int RegionId { get; set; }
        public int SectorId { get; set; }
        public int IndustryId { get; set; }
        public string OtherIndustry { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int DesignationId { get; set; }
        public int? CompanyImageId { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual CompanyLogo CompanyImage { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Industry Industry { get; set; }
        public virtual Region Region { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Internship> Internships { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Hired> Hireds { get; set; }
        public virtual ICollection<RecievedMsgFromCompany> RecievedMsgFromCompanies { get; set; }
        public virtual ICollection<SentMsgToHiredIntern> SentMsgToHiredInterns { get; set; }
        public virtual ICollection<VerifyCompany> VerifyCompanies { get; set; }
    }
}
