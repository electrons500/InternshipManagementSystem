using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class VerifyCompany
    {
        public string CompanyId { get; set; }
        public int VerifyCategoryId { get; set; }

        public virtual Company Company { get; set; }
        public virtual VerifyCategory VerifyCategory { get; set; }
    }
}
