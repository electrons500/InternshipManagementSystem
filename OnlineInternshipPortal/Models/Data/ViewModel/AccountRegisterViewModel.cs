using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountRegisterViewModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }

        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
       
        [Display(Name = "Middle name")]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage = "This field is required")]
      
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [NotMapped]
       
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "This field is required")]
        public int GenderId { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "This field is required")]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9-\s]*$", ErrorMessage = "Only Alphabets and numbers are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Hometown")]
        public string HomeTown { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Region of hometown")]
        public int RegionId { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "This field is required")]
        public SelectList RegionList { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9-\s,.]*$", ErrorMessage = "Only Alphabets and numbers are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Residence")]
        public string Residence { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9-\s,.]*$", ErrorMessage = "Only Alphabets and numbers are allowed.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Phone]
        [StringLength(15, ErrorMessage = "The telephone number must be maximum {1} and mininum {2}", MinimumLength = 10)]
        [Display(Name = "Phone number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
       

        [Display(Name ="Profile picture")]
        public byte[] ProfilePic { get; set; }
        [NotMapped]
        [Display(Name = "Profile picture")]
        public IFormFile UserImage { get; set; }

        [NotMapped]
        [DisplayName("Date of registration")]
        public DateTime? RegistrationDate { get; set; }

    }
}
