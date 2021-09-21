using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Gender
    {
        public Gender()
        {
            Interns = new HashSet<Intern>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Intern> Interns { get; set; }
    }
}
