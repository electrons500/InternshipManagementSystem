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
    public class InternsViewModel
    {
        [Key]
        [DisplayName("Intern no")]
        public string InternId { get; set; }
        [Required(ErrorMessage ="Your first name is required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }
      
        [DisplayName("Middle name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Your Last name is required")]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Your date of birth is required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Your Gender is required")]
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Your home town is required")]
        [DisplayName("Home town")]
        public string HomeTown { get; set; }
        [Required(ErrorMessage = "Your region is required")]
        [DisplayName("Region of hometown")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Your residence is required")]
        [DisplayName("Residence")]
        public string Residence { get; set; }
        [Required(ErrorMessage = "Your Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Your Gender is required")]
        [Phone]
        [DisplayName("Phone number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Your school is required")]
        [DisplayName("School")]
        public int SchoolId { get; set; }
        [NotMapped]
        [DisplayName("School")]
        public SelectList SchoolList { get; set; }
        [NotMapped]
        [DisplayName("School")]
        public string SchoolName { get; set; }


        [Required(ErrorMessage = "Your student number is required")]
        [DisplayName("Student number")]
        public string StudentIdCardNumber { get; set; }
        [Required(ErrorMessage = "Your program of study is required")]
        [DisplayName("Program of study")]
        public string Course { get; set; }
       
        [DisplayName("Upload photo")]
        public string Photo { get; set; }
        [DisplayName("Upload photo")]
        [NotMapped]
        public IFormFile StudentImage { get; set; } 
        [Required(ErrorMessage = "Your CV is required")]
        [DisplayName("Upload CV in pdf format only")]
      
        public int CvId { get; set; }
        [DisplayName("Upload CV in pdf format only")]
        [NotMapped]
        public IFormFile CVfile { get; set; }
        [DisplayName("Upload CV in pdf format only")]
        [NotMapped]
        public string CVfilename { get; set; }
        [NotMapped]
        [DisplayName("Gender")]
        public SelectList GenderList { get; set; }
        [NotMapped]
        [DisplayName("Gender")]
        public string GenderName { get; set; }
        [DisplayName("Region of hometown")]
        [NotMapped]
        public SelectList RegionList { get; set; }
        [NotMapped]
        [DisplayName("Region of hometown")]
        public string RegionName { get; set; }

        //Guardian
        [Required(ErrorMessage = "Your guardian name is required")]
        [DisplayName("Guardian name")]
        public int GuardianId { get; set; }
        [Required(ErrorMessage = "Your guardian name is required")]
        [DisplayName("Guardian name")]
        public string GuardianName { get; set; }
        [Required(ErrorMessage = "Your guardian phone number is required")]
        [DisplayName("Guardian phone number")]
        public string GuardianContactNumber { get; set; }
        [Required(ErrorMessage = "Your guardian residence is required")]
        [DisplayName("Guardian residence")]
        public string GuardianResidence { get; set; }
        [Required(ErrorMessage = "Relationship")]
        [DisplayName("Relationship")]
        public int GuardianCategoryId { get; set; }
        [NotMapped]
        [DisplayName("Relationship")]
        public SelectList GuardianCategoryList { get; set; }
        [NotMapped]
        [DisplayName("Relationship")]
        public string GuardianCategoryName { get; set; }

        [NotMapped]
        [DisplayName("Date of registration")]
        public DateTime? RegistrationDate { get; set; } 


    }
}
