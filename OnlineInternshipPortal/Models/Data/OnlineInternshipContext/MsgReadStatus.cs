using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class MsgReadStatus
    {
        public MsgReadStatus()
        {
            RecievedMsgFromCompanies = new HashSet<RecievedMsgFromCompany>();
        }

        public int MsgReadStatusId { get; set; }
        public string MsgReadStatusName { get; set; }

        public virtual ICollection<RecievedMsgFromCompany> RecievedMsgFromCompanies { get; set; }
    }
}
