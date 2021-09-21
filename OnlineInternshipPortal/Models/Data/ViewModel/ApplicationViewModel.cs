using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class ApplicationViewModel
    {
        [Key]
        public string ApplicationId { get; set; }
        [DisplayName("Application Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfApplication { get; set; }
        [DisplayName("Intern name")]
        public string InternId { get; set; }
        [DisplayName("Intern name")]
        [NotMapped]
        public string InternName { get; set; }
        [DisplayName("Internship")]
        public string InternshipId { get; set; }
        [DisplayName("Internship")]
        [NotMapped]
        public string InternshipTitle { get; set; }
        [DisplayName("Company name")]
        public string CompanyId { get; set; }
        [DisplayName("Company name")]
        [NotMapped]
        public string CompanyName { get; set; }
        [DisplayName("Intern CV")]      
        public int CvId { get; set; }
        [NotMapped]
        [DisplayName("Intern CV")]
        [Url]
        public string CvName { get; set; }
        [DisplayName("Internship granted")]
        public int ApprovalId { get; set; }
        [DisplayName("Internship granted")]
        [NotMapped]
        public string ApprovalName { get; set; }
        [DisplayName("Internship granted")]
        [NotMapped]
        public SelectList ApprovalList { get; set; }


    }
}
