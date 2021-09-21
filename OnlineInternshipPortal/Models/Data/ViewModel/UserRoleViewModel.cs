using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.ViewModel
{
    public class UserRoleViewModel
    {
        [Key]
        public string RoleId { get; set; }
        [NotMapped]
        public string RoleName { get; set; }
        public string UserId { get; set; }
        [NotMapped]
        public string UserFullName { get; set; }
        [NotMapped]
        [Phone]
        public string UserPhone { get; set; }  

    }
}
