using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class GuardianCategoryViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int GuardianCategoryId { get; set; }

        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Guardian category.eg father,Mother")]
        

        public string Name { get; set; }
    }
}
