using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class SchoolService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;

        public SchoolService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }
        //
       public List<SchoolViewModel> GetSchools()
        {
            List<School> schools = _db.Schools.ToList();
            List<SchoolViewModel> model = schools.Select(x => new SchoolViewModel
            {
                SchoolId = x.SchoolId,
                SchoolName = x.SchoolName
            }).ToList();

            return model;
        }

        public bool AddSchool(SchoolViewModel model)
        {
            School school = new()
            {
                SchoolName = model.SchoolName
            };
            _db.Schools.Add(school);
            _db.SaveChanges();

            return true;
        }

        public SchoolViewModel GetSchoolDetails(int id)
        {
            School school = _db.Schools.Where(x => x.SchoolId == id).FirstOrDefault();
            SchoolViewModel model = new()
            {
                SchoolId = school.SchoolId,
                SchoolName = school.SchoolName
            };
            
            return model;

        }

        public bool UpdateSchool(SchoolViewModel model)
        {
            School school = _db.Schools.Where(x => x.SchoolId == model.SchoolId).FirstOrDefault();
            school.SchoolName = model.SchoolName;
            _db.Schools.Update(school);
            _db.SaveChanges();

            return true;
        }
        public bool DeleteSchool(int id)
        {
            School school = _db.Schools.Where(x => x.SchoolId == id).FirstOrDefault();
            _db.Schools.Remove(school);
            int i = _db.SaveChanges();
            if(i > 0)
            {
                return true;
            }
            return false;
        }

    }
}
