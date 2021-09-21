using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class SentMsgToHiredIntern
    {
        public string SentId { get; set; }
        public string Subject { get; set; }
        public string Messagebody { get; set; }
        public string Attachments { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public DateTime SentDate { get; set; }
        public string SentTime { get; set; }
        public string CompanyId { get; set; }
        public int SentStatusId { get; set; }
        public string InternId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Intern Intern { get; set; }
        public virtual SentStatus SentStatus { get; set; }
    }
}
