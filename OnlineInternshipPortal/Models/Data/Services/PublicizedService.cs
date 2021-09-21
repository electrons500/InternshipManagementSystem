using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class PublicizedService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public PublicizedService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Add values to publicize tbl
        public void AddValueToPublicize()
        {
            var count = _db.Publicizes.Count();
            if(count == 0)
            {
                Publicize publicizeOne = new()
                {
                    Name = "Yes"
                };
                _db.Publicizes.Add(publicizeOne);
                Publicize publicizeTwo = new()
                {
                    Name = "No"
                };
                _db.Publicizes.Add(publicizeTwo);
                _db.SaveChanges();

            }
        }

    }
}
