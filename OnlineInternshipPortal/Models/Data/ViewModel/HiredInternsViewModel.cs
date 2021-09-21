using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class HiredInternsViewModel
    {
        [Key]
        public int HireId { get; set; }
        [DisplayName("Date hired")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [DisplayName("Intern")]
        public string InternId { get; set; }
        [NotMapped]
        [DisplayName("Intern name")]
        public string InternName { get; set; }
        [NotMapped]      
        [DisplayName("Intern email")]
        [EmailAddress]
        public string InternEmail { get; set; }
        [DisplayName("Company name")]
        public string CompanyId { get; set; }
        [DisplayName("Company name")]
        [NotMapped]
        public string CompanyName { get; set; }
    }
}
