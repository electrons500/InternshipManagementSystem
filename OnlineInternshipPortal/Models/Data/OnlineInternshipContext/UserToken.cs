using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class UserToken
    {
        public string LoginProvider { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
