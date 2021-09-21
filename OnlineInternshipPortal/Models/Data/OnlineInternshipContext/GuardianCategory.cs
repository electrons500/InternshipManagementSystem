using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class GuardianCategory
    {
        public GuardianCategory()
        {
            Guardians = new HashSet<Guardian>();
        }

        public int GuardianCategoryId { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Only Alphabets are allowed.")]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public virtual ICollection<Guardian> Guardians { get; set; }
    }
}
