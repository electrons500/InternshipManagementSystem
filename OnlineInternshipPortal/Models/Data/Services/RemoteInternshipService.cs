using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class RemoteInternshipService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public RemoteInternshipService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Add values to Romote intenship tbl
        public void AddRemoteInternship()
        {
            var countRemote = _db.Remotes.Count();
            if(countRemote == 0)
            {
                Remote remoteOne = new()
                {
                    Name = "Yes"
                };
                _db.Remotes.Add(remoteOne);
                Remote remoteTwo = new()
                {
                    Name = "No"
                };
                _db.Remotes.Add(remoteTwo);
                _db.SaveChanges();


            }
        }

    }
}
