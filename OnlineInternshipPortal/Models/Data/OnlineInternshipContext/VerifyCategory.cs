using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class VerifyCategory
    {
        public VerifyCategory()
        {
            VerifyCompanies = new HashSet<VerifyCompany>();
        }

        public int VerifyCategoryId { get; set; }
        public string VerifyName { get; set; }

        public virtual ICollection<VerifyCompany> VerifyCompanies { get; set; }
    }
}
