using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class InternshipStatusService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public InternshipStatusService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Add values to internship status db
        public void AddInternshipStatus()
        {
            var countstatus = _db.InternshipStatuses.Count();
            if(countstatus == 0)
            {
                InternshipStatus statusOne = new()
                {
                    Name = "Full Time"
                };
                _db.InternshipStatuses.Add(statusOne);
                InternshipStatus statusTwo = new()
                {
                    Name = "Part Time"
                };
                _db.InternshipStatuses.Add(statusTwo);
                _db.SaveChanges();

                //Approval id from Application table
                int InternshipApprovalCount = _db.InternshipApprovals.Count();
                if(InternshipApprovalCount == 0)
                {
                    InternshipApproval approvalOne = new()
                    {
                        Name = "No"
                    };
                    _db.InternshipApprovals.Add(approvalOne);
                    InternshipApproval approvalTwo = new()
                    {
                        Name = "Yes"
                    };
                    _db.InternshipApprovals.Add(approvalTwo);
                    _db.SaveChanges();

                }


            }
        }

    }
}
