using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class IndustryViewModel
    { 
        [Key]
        [DisplayName("S/No")]
        public int IndustryId { get; set; }

        [DisplayName("Industries")] 
        [RegularExpression(@"^[a-zA-Z-\s&]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage ="This field is required")]
        public string IndustryName { get; set; }
    }
}
