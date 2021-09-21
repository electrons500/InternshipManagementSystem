using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class RecievedStatus
    {
        public RecievedStatus()
        {
            RecievedMsgFromCompanies = new HashSet<RecievedMsgFromCompany>();
        }

        public int ReceivedStatusId { get; set; }
        public string ReceiveStatusName { get; set; }

        public virtual ICollection<RecievedMsgFromCompany> RecievedMsgFromCompanies { get; set; }
    }
}
