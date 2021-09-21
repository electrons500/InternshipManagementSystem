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
    public class InternshipViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public string InternshipId { get; set; }  
        [Required(ErrorMessage = "This field is mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is mandatory")]
        public string Location { get; set; }
        [Required(ErrorMessage = "This field is mandatory")]
        public string Duration { get; set; }
        [DisplayName("Work description")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string WorkDescription { get; set; }
        [DisplayName("Skills required")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string SkillsRequired { get; set; }
        [DisplayName("Additional information")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string AdditionalInfo { get; set; }
        [DisplayName("Deadline date")]
        [Required(ErrorMessage = "This field is mandatory")]
        [DataType(DataType.Date)]
        public DateTime DeadLineDate { get; set; }
        [DisplayName("Who can apply")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string WhoCanApply { get; set; }
        [DisplayName("Posted date")]
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
        [DisplayName("Posted Time")]
        [DataType(DataType.Time)]
        public string PostedTime { get; set; }
        [DisplayName("Internship status")]       
        public int InternshipStatusId { get; set; }
        [NotMapped]
        [DisplayName("Internship status")]
        public SelectList InternshipStatusList { get; set; }
        [NotMapped]
        [DisplayName("Internship status")]
        public string InternshipStatusName { get; set; }
        [DisplayName("Remote")]
        [Required(ErrorMessage = "This field is mandatory")]
        public int RemoteId { get; set; }
        [NotMapped]
        [DisplayName("Remote")]
        [Required(ErrorMessage = "This field is mandatory")]
        public SelectList RemoteList { get; set; }
        [NotMapped]
        [DisplayName("Remote")]
        public string RemoteName { get; set; }

        [DisplayName("Publish")]
        [Required(ErrorMessage = "This field is mandatory")]
        public int PublicizeId { get; set; }
        [NotMapped]
        [DisplayName("Publish")]
        [Required(ErrorMessage = "This field is mandatory")]
        public SelectList PublicizeList { get; set; }
        [NotMapped]
        [DisplayName("Publish")]
        public string PublicizeName { get; set; }

        [DisplayName("Industry")]
        [Required(ErrorMessage = "This field is mandatory")]
        public int IndustryId { get; set; }
        [NotMapped]
        [DisplayName("Industry")]
        [Required(ErrorMessage = "This field is mandatory")]
        public SelectList IndustryList { get; set; }
        [NotMapped]
        [DisplayName("Industry")]
        public string IndustryName { get; set; }

        [DisplayName("Company")]

        public string CompanyId { get; set; }
        [DisplayName("Company")]
        public string CompanyName { get; set; }
        [DisplayName("Company Logo")]
        public int? CompanyImageId { get; set; }

        [NotMapped]
        [DisplayName("Company Logo")]
        public byte[] Companylogo { get; set; }


        //The ppt below are not part of DB
        [NotMapped]
        public string PostedDuration { get; set; } 
        [NotMapped]
        public List<InternshipViewModel> GetInternshipViewModels { get; set; }

    }
}
