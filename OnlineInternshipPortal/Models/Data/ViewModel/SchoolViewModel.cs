using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class SchoolViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int SchoolId { get; set; }
        
        [DisplayName("School name")]
        [RegularExpression(@"^[a-zA-Z-\s&]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        public string SchoolName { get; set; }
    }
}
