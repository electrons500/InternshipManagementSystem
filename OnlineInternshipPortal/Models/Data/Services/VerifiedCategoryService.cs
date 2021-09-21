using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class VerifiedCategoryService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public VerifiedCategoryService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Add category
        public void AddVerifiedCategory()
        {
            var CountCategory = _db.VerifyCategories.Count();
            if(CountCategory == 0)
            {
                VerifyCategory categOne = new()
                {
                    VerifyName = "Approved"
                };
                _db.VerifyCategories.Add(categOne);
                VerifyCategory categTwo = new()
                {
                    VerifyName = "Pending"
                };
                _db.VerifyCategories.Add(categTwo);
                VerifyCategory categThree = new()
                {
                    VerifyName = "Denied"
                };
                _db.VerifyCategories.Add(categThree);

                _db.SaveChanges();

            }
        }


    }
}
