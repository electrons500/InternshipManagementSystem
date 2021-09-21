using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class IndustryService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;

        public IndustryService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //List of industries
        public List<IndustryViewModel> GetIndustries()
        {
            List<Industry> industries = _db.Industries.ToList();
            List<IndustryViewModel> model = industries.Select(x => new IndustryViewModel
            {
                IndustryId = x.IndustryId,
                IndustryName = x.IndustryName
            }).ToList();

            return model;
        }

        //Get industry details
        public IndustryViewModel GetIndustryDetails(int id)
        {
            Industry industry = _db.Industries.Where(x => x.IndustryId == id).FirstOrDefault();
            IndustryViewModel model = new()
            {
                IndustryId = industry.IndustryId,
                IndustryName = industry.IndustryName
            
            };

            return model;
        }

        //Add an industry
        public bool AddIndustry(IndustryViewModel model)
        {
            Industry industry = new()
            {
                IndustryName = model.IndustryName
            };

            _db.Industries.Add(industry);
             int a  =_db.SaveChanges();
            if(a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            


        }
        //Update industry
        public bool UpdateIndustry(IndustryViewModel model)
        {
            Industry industry = _db.Industries.Where(x => x.IndustryId == model.IndustryId).FirstOrDefault();
            industry.IndustryName = model.IndustryName;
            _db.Industries.Update(industry);
            _db.SaveChanges();

            return true;

        }

        //Remove industry
        public bool DeleteIndustry(int id)
        {
            Industry industry = _db.Industries.Where(x => x.IndustryId == id).FirstOrDefault();
            _db.Industries.Remove(industry);
            _db.SaveChanges();
            return true;
        }


    }
}
