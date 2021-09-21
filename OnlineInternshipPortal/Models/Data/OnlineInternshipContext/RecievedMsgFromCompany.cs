using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class RecievedMsgFromCompany
    {
        public string RecieveId { get; set; } 
        public string Subject { get; set; }
        public string Messagebody { get; set; }
        public string Attachments { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; } 
        public DateTime ReceivedDate { get; set; }
        public string ReceivedTime { get; set; } 
        public string CompanyId { get; set; }
        public int ReceivedStatusId { get; set; }
        public int MsgReadStatusId { get; set; }
        public string InternId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Intern Intern { get; set; }
        public virtual MsgReadStatus MsgReadStatus { get; set; }
        public virtual RecievedStatus ReceivedStatus { get; set; }
    }
}
