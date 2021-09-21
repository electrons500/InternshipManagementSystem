using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class SentStatus
    {
        public SentStatus()
        {
            SentMsgToHiredInterns = new HashSet<SentMsgToHiredIntern>();
        }

        public int SentStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<SentMsgToHiredIntern> SentMsgToHiredInterns { get; set; }
    }
}
