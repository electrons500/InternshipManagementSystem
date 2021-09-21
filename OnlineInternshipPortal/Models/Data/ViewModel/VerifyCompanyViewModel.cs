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
    public class VerifyCompanyViewModel
    {      
        [Key]
        [DisplayName("Company")]
        public string CompanyId { get; set; }
        [DisplayName("Company")]
        [NotMapped]
        public string CompanyName { get; set; }

        [DisplayName("Verification status")]
        
        public int VerifyCategoryId { get; set; }
        [DisplayName("Verification status")]
        [NotMapped]

        public string VerifyCategoryName { get; set; }
        [NotMapped]
        [DisplayName("Verification status")]
        public SelectList VerifyCompanyList { get; set; }
  
       

    }
}
