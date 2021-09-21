using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class UsersViewModel
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        [NotMapped]
        public string GenderName { get; set; } 
        public string HomeTown { get; set; }
        public int RegionId { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        public string Residence { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePic { get; set; }
        [NotMapped]
        [DisplayName("Date of registration")]
        public DateTime? RegistrationDate { get; set; }


    }
}
