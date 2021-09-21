using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class ReceivedMsgFromCompanyViewModel
    {
        [Key]
        public string RecieveId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Subject { get; set; }
        [DisplayName("Message")]

        [Required(ErrorMessage = "This field is required")]
        public string Messagebody { get; set; }
        [DisplayName("Attachment")]

        [Required(ErrorMessage = "This field is required")]
        public string Attachments { get; set; }
        [DisplayName("Add attachment")]
        [NotMapped]
          
        public string FileType { get; set; }
        [NotMapped]
        public string Extension { get; set; }
        [NotMapped]
        public string FilePath { get; set; }
        [DisplayName("Date Sent")]
        public DateTime ReceivedDate { get; set; }
        [DisplayName("Time Sent")]
        public string ReceivedTime { get; set; }
        [DisplayName("Company name")]
        public string CompanyId { get; set; }
        [NotMapped]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
        [NotMapped]
        [DisplayName("Company email")]
        public string CompanyEmail { get; set; }
        [DisplayName("Sent status")]
        public int SentStatusId { get; set; }
        [DisplayName("Sent status")]
        [NotMapped]
        public string SentStatusName { get; set; }
        [DisplayName("Intern name")]
        public string InternId { get; set; }
        [NotMapped]
        [DisplayName("Intern name")]
        public string InternName { get; set; }
        [NotMapped]
        [DisplayName("Intern email")]
        [EmailAddress]
        public string InternEmail { get; set; }
        
        [DisplayName("Message received")]
        public int ReceivedStatusId { get; set; }
        [NotMapped]
        [DisplayName("Message received")]
        public string ReceiveStatusName { get; set; }
       
        [DisplayName("Nessage Read")]
        public int MsgReadStatusId { get; set; }
        [NotMapped]
        [DisplayName("Nessage Read")]
        public string MsgReadStatusName { get; set; }

    }
}
