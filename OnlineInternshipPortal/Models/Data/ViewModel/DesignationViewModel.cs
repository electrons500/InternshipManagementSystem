using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class DesignationViewModel
    {
        [Key]
        [DisplayName("S/No.")]
        public int DesignationId { get; set; }
        [DisplayName("Designation name")]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string DesignationName { get; set; }
    }
}
