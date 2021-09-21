using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class VerifyCompanyService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;
        private IConfiguration _Configuration;
        public VerifyCompanyService(OnlineInternshipContext.OnlineInternshipContext db,IConfiguration configuration)
        {
            _db = db;
            _Configuration = configuration;
        }

        //Create Verification status
        public VerifyCompanyViewModel CreateVerifications()
        {
            VerifyCompanyViewModel model = new()
            {
                VerifyCompanyList = new SelectList(_db.VerifyCategories, "VerifyCategoryId", "VerifyName")
            };

            return model;
        }
        
        //List of  pending companies and their verification status
        public List<VerifyCompanyViewModel> GetPendingCompanies() 
        {
            List<VerifyCompany> verifyCompanies = _db.VerifyCompanies.Where(x => x.VerifyCategoryId == 2)
                                                                     .Include(x => x.Company)
                                                                     .Include(x => x.VerifyCategory)
                                                                     .ToList();
            List<VerifyCompanyViewModel> model = verifyCompanies.Select(x => new VerifyCompanyViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                VerifyCategoryId = x.VerifyCategoryId,
                VerifyCategoryName = x.VerifyCategory.VerifyName
            }).ToList();

            return model;
        }

         //List of denied companies 
        public List<VerifyCompanyViewModel> GetDeniedCompanies() 
        {
            List<VerifyCompany> verifyCompanies = _db.VerifyCompanies.Where(x => x.VerifyCategoryId == 1)
                                                                     .Include(x => x.Company)
                                                                     .Include(x => x.VerifyCategory)
                                                                     .ToList();
            List<VerifyCompanyViewModel> model = verifyCompanies.Select(x => new VerifyCompanyViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                VerifyCategoryId = x.VerifyCategoryId,
                VerifyCategoryName = x.VerifyCategory.VerifyName
            }).ToList();

            return model;
        }

         //List of approved companies 
        public List<VerifyCompanyViewModel> GetApprovedCompanies() 
        {
            List<VerifyCompany> verifyCompanies = _db.VerifyCompanies.Where(x => x.VerifyCategoryId == 3)
                                                                     .Include(x => x.Company)
                                                                     .Include(x => x.VerifyCategory)
                                                                     .ToList();
            List<VerifyCompanyViewModel> model = verifyCompanies.Select(x => new VerifyCompanyViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                VerifyCategoryId = x.VerifyCategoryId,
                VerifyCategoryName = x.VerifyCategory.VerifyName
            }).ToList();

            return model;
        }





        //Get Details
        public VerifyCompanyViewModel GetVerifiesDetails(string companyId)
        {
            VerifyCompany verifyCompany = _db.VerifyCompanies.Where(x => x.CompanyId == companyId)
                                                             .Include(x => x.Company)
                                                             .Include(x => x.VerifyCategory)
                                                             .FirstOrDefault();
            VerifyCompanyViewModel model = new()
            {

                VerifyCategoryId = verifyCompany.VerifyCategoryId,
                VerifyCategoryName = verifyCompany.VerifyCategory.VerifyName,
                VerifyCompanyList = new SelectList(_db.VerifyCategories, "VerifyCategoryId", "VerifyName"),
                CompanyName = verifyCompany.Company.CompanyName,
                CompanyId = verifyCompany.CompanyId

            };

            return model;
        }

        // Edit
        public bool UpdateVerifyCompany(VerifyCompanyViewModel model)
        {
            VerifyCompany verifyCompany = _db.VerifyCompanies.Where(x => x.CompanyId == model.CompanyId)
                                                            .Include(x => x.Company)
                                                            .Include(x => x.VerifyCategory)
                                                            .FirstOrDefault();

            
            verifyCompany.VerifyCategoryId = model.VerifyCategoryId;
            _db.VerifyCompanies.Update(verifyCompany);

            _db.SaveChanges();

            return true;


        }

        // ADO.net method of updating DB
        public bool UpdateVerifyCompanyWithoutEF(string companyId,int verifyId)
        {
            string sql = "update VerifyCompany set VerifyCategoryId ='" + verifyId + "' where CompanyId ='"+ companyId +"'";
            int i;
            using (SqlConnection con = new(GetConnectionString()))
            {
                using (SqlCommand cmd = new(sql,con))
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            if(i> 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //connection string from confiuration file
        private string GetConnectionString()
        {
            return this._Configuration.GetConnectionString("Conn");
        }

    }
}
