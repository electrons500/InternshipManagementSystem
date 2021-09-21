using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class HiredInternService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;

        public HiredInternService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //list of hired interns based on company ie company will only view their own intern
        public List<HiredInternsViewModel> GetHiredInternsByCompany(ApplicationUser user)
        {
            var company = _db.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            List<Hired> internhired = _db.Hireds.Where(x => x.CompanyId == company.CompanyId).Include(x => x.Company)
                                                                                             .Include(x => x.Intern)
                                                                                             .ToList();
            List<HiredInternsViewModel> model = internhired.Select(x => new HiredInternsViewModel
            {
                HireId = x.HireId,
                InternId = x.InternId,
                InternEmail = x.Intern.Email,
                InternName = x.Intern.FullName,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                HireDate = x.HireDate
            }).ToList();

            return model;

        }

         //list of hired interns for admin
        public List<HiredInternsViewModel> GetHiredInterns()
        {
            
            List<Hired> internhired = _db.Hireds.Include(x => x.Company)
                                                .Include(x => x.Intern)
                                                .ToList();
            List<HiredInternsViewModel> model = internhired.Select(x => new HiredInternsViewModel
            {
                HireId = x.HireId,
                InternId = x.InternId,
                InternEmail = x.Intern.Email,
                InternName = x.Intern.FullName,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                HireDate = x.HireDate
            }).ToList();

            return model;

        }

        //delete Hired intern
        public bool RemoveHiredIntern(int id)
        {
            Hired hired = _db.Hireds.Where(x => x.HireId == id).FirstOrDefault();
            _db.Hireds.Remove(hired);
           int i = _db.SaveChanges();

            if(i > 0)
            {
                return true;
            }

            return false;

        }

    }
}
