using Microsoft.AspNetCore.Http;
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
    public class CompanyViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public string CompanyId { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9-\s.,]*$", ErrorMessage = "Only postal address are allowed.")]
        [Required]
        [DisplayName("Company address")]
        public string CompanyAddress { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required]
        [DisplayName("Company location")]
        public string CompanyLocation { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9-\s]*$", ErrorMessage = "Only Alphabets and numbers are allowed.")]
        [Required]
        [DisplayName("Registered number")]
        public string CompanyRegNo { get; set; }
       
        [Required]
        [DisplayName("Company description")]
        public string CompanyDescription { get; set; }
       
        [DisplayName("Company website link")]
        [DataType(DataType.Url)]
        public string Companywebsite { get; set; }
        [DisplayName("Company video link")]
        [DataType(DataType.Url)]
        public string CompanyVideoLink { get; set; }
        [RegularExpression(@"^[0-9-\s+]*$", ErrorMessage = "Only numbers are allowed.")] 
        [Required]
        [DisplayName("Company phone number")]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [DisplayName("Company email address")]
        [EmailAddress]
        public string CompanyEmail { get; set; }
        [Required]
        [DisplayName("Region")]
        public int RegionId { get; set; }
        [NotMapped]
        [DisplayName("Region")]
        public SelectList RegionList { get; set; }
        [NotMapped]
        [DisplayName("Region")]
        public string RegionName { get; set; } 
        [Required]
        [DisplayName("Sector")]
        public int SectorId { get; set; }
        [NotMapped]
        [DisplayName("Sector")]
        public SelectList SectorList { get; set; }
        [NotMapped]
        [DisplayName("Sector")]
        public string SectorName { get; set; }
        [Required]
        [DisplayName("Industry")]
        public int IndustryId { get; set; }
        [NotMapped]
        [DisplayName("Industry")]
        public SelectList IndustryList { get; set; }
        [NotMapped]
        [DisplayName("Industry")]
        public string IndustryName { get; set; }
        [DisplayName("Other industry")]
        public string OtherIndustry { get; set; }
        [DisplayName("Employer name")]
        public string UserId { get; set; }
        [NotMapped]
        [DisplayName("Employer name")]
        public string EmployerFullName { get; set; }

        [Required]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [NotMapped]
        [DisplayName("Designation")]
        public SelectList DesignationList { get; set; }
        [NotMapped]
        [DisplayName("Designation")]
        public string DesignationName { get; set; }
        [DisplayName("Company logo")]
       
        public int? CompanyImageId { get; set; }
        [NotMapped]
        
        [DisplayName("Company logo")]
        public IFormFile ImageIformFile { get; set; }
        [NotMapped]
        [DisplayName("Company logo")]
        public byte[] Companylogo { get; set; }
        [NotMapped]
        [DisplayName("Date of registration")]
        public DateTime? RegistrationDate { get; set; }

    }
}
