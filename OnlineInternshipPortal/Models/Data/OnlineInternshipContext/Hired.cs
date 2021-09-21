using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class Hired
    {
        public int HireId { get; set; }
        public DateTime HireDate { get; set; }
        public string InternId { get; set; }
        public string CompanyId { get; set; } 

        public virtual Company Company { get; set; }
        public virtual Intern Intern { get; set; }
    }
}
