using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class User
    {
        public User()
        {
            Companies = new HashSet<Company>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        public string HomeTown { get; set; }
        public int RegionId { get; set; }
        public string Residence { get; set; }
        public string Address { get; set; }
        public byte[] ProfilePic { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
