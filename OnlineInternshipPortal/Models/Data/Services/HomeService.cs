using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class HomeService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;

        public HomeService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Insert these values in their various tables
       public void InsertValues()
        {
            var industries = _db.Industries.Count();
            if (industries == 0)
            {
                Industry industryOther = new()
                {
                    IndustryName = "Other"
                };
                _db.Industries.Add(industryOther);
                _db.SaveChanges();

                Industry industry = new()
                {
                    IndustryName = "Oil and Gas"
                };
                _db.Industries.Add(industry);

                 Industry industry1 = new()
                {
                    IndustryName = "Telecommunication"
                };
                _db.Industries.Add(industry1);
                 Industry industry2 = new()
                {
                    IndustryName = "Banking and Finance"
                };
                _db.Industries.Add(industry2);

                _db.SaveChanges();

            }

            //Desgination
            var desg = _db.Designations.Count();
            if(desg == 0)
            {
                Designation designation = new()
                {
                    DesignationName = "CEO"
                };
                _db.Designations.Add(designation);
                Designation designation1 = new()
                {
                    DesignationName = "General Manager"
                };
                _db.Designations.Add(designation1);
                 Designation designation2 = new()
                {
                    DesignationName = "Human Resource Manager"
                };
                _db.Designations.Add(designation2);
                _db.SaveChanges();
            }

            //insert some university
            var schoolCount = _db.Schools.Count();
            if(schoolCount == 0)
            {
                School schoolOne = new()
                {
                    SchoolName = "University of Ghana"
                };
                _db.Schools.Add(schoolOne);

                 School schoolTwo = new()
                {
                    SchoolName = "University of Cape Coast"
                };
                _db.Schools.Add(schoolTwo);


                School schoolThree = new()
                {
                    SchoolName = "University of Development Studies"
                };
                _db.Schools.Add(schoolThree);

                 School schoolFour = new()
                {
                    SchoolName = "University of Mines & Technology"
                };
                _db.Schools.Add(schoolFour);

                 School schoolFive = new()
                {
                    SchoolName = "Kwame Nkrumah University of Science & Technology"
                };
                _db.Schools.Add(schoolFive);

                _db.SaveChanges();



            }


            //Insert Guardian category
            var countGuardianCategory = _db.GuardianCategories.Count();
            if(countGuardianCategory == 0)
            {
                GuardianCategory g1 = new()
                {
                    Name = "Father"
                };
                _db.GuardianCategories.Add(g1);

                GuardianCategory g2 = new()
                {
                    Name = "Mother"
                };
                _db.GuardianCategories.Add(g2);

                 GuardianCategory g3 = new()
                {
                    Name = "Son"
                };
                _db.GuardianCategories.Add(g3);

                 GuardianCategory g4 = new()
                {
                    Name = "Daughter"
                };
                _db.GuardianCategories.Add(g4);


                _db.SaveChanges();

            }

        }
    }
}
