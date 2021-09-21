using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class SectorService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public SectorService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //create sector if none is found in the DB
        public void CreateSectors()
        {
            var countsector = _db.Sectors.Count();
            if(countsector == 0)
            {
                //add these to db

                Sector sector1 = new()
                {
                    SectorName = "Public sector"
                };
                _db.Sectors.Add(sector1);
                Sector sector2 = new()
                {
                    SectorName = "Private sector"
                };
                _db.Sectors.Add(sector2);
                _db.SaveChanges();

            }
        }
    }
}
