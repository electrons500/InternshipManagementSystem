using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Intern
    {
        public Intern()
        {
            Applications = new HashSet<Application>();
            Hireds = new HashSet<Hired>();
            RecievedMsgFromCompanies = new HashSet<RecievedMsgFromCompany>();
            SentMsgToHiredInterns = new HashSet<SentMsgToHiredIntern>();
        }

        public string InternId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        public string HomeTown { get; set; }
        public int RegionId { get; set; }
        public string Residence { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
        public string StudentIdCardNumber { get; set; }
        public string Course { get; set; }
        public int GuardianId { get; set; }
        public string Photo { get; set; }
        public int CvId { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual Cv Cv { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Guardian Guardian { get; set; }
        public virtual Region Region { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Hired> Hireds { get; set; }
        public virtual ICollection<RecievedMsgFromCompany> RecievedMsgFromCompanies { get; set; }
        public virtual ICollection<SentMsgToHiredIntern> SentMsgToHiredInterns { get; set; }
    }
}
