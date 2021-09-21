using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class CompanyService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;
      
        public CompanyService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
           
        }

        //Create company
        public CompanyViewModel CreateCompany(ApplicationUser user)
        {
            var userfullname = user.FullName;

            CompanyViewModel model = new()
            {
                SectorList = new SelectList(_db.Sectors, "SectorId", "SectorName"),
                IndustryList = new SelectList(_db.Industries, "IndustryId", "IndustryName"),
                DesignationList = new SelectList(_db.Designations, "DesignationId", "DesignationName"),
                RegionList = new SelectList(_db.Regions, "RegionId","RegionName"),
                EmployerFullName = userfullname
                
            };

            return model;

        }

        //List of companies resgistered in the system  for admin only
        public List<CompanyViewModel> GetCompanies()
        {
            List<Company> companies = _db.Companies.Include(x => x.Sector)
                                                   .Include(x => x.Industry)
                                                   .Include(x => x.Designation)
                                                   .Include(x => x.Region)
                                                   .Include(x => x.ApplicationUser)
                                                   .Include(x => x.CompanyImage)
                                                   .ToList();
            List<CompanyViewModel> model = companies.Select(x => new CompanyViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.CompanyName,
                CompanyAddress = x.CompanyAddress,
                CompanyLocation = $"{x.CompanyLocation},{ x.Region.RegionName }",
                CompanyRegNo = x.CompanyRegNo,
                CompanyDescription = x.CompanyDescription,
                Companywebsite = x.Companywebsite,
                CompanyVideoLink = x.CompanyVideoLink,
                ContactNumber = x.ContactNumber,
                CompanyEmail = x.CompanyEmail,
                RegionId = x.RegionId,
                RegionName = x.Region.RegionName,
                SectorId =x.SectorId,
                SectorName =x.Sector.SectorName,
                IndustryId = x.IndustryId,
                IndustryName = x.Industry.IndustryName,
                UserId = x.UserId,
                EmployerFullName = x.ApplicationUser.FullName,
                DesignationId = x.DesignationId,
                DesignationName = x.Designation.DesignationName,
                CompanyImageId = x.CompanyImageId,
                Companylogo = x.CompanyImage.Image,
                RegistrationDate = x.RegistrationDate
                
            }).ToList();

            return model;
        }
        //List table of Company information.Here company sees his company info
        public List<CompanyViewModel> CompanyInformation(ApplicationUser user)
        {
           
            List<Company> companies = _db.Companies.Where(x => x.UserId == user.Id)
                                                   .Include(x => x.Sector)
                                                   .Include(x => x.Industry)
                                                   .Include(x => x.Designation)
                                                   .Include(x => x.Region)
                                                   .Include(x => x.ApplicationUser)
                                                   .Include(x => x.CompanyImage)
                                                   .ToList();
            List<CompanyViewModel> model = companies.Select(x => new CompanyViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.CompanyName,
                CompanyAddress = x.CompanyAddress,
                CompanyLocation = $"{x.CompanyLocation},{ x.Region.RegionName }",
                CompanyRegNo = x.CompanyRegNo,
                CompanyDescription = x.CompanyDescription,
                Companywebsite = x.Companywebsite,
                CompanyVideoLink = x.CompanyVideoLink,
                ContactNumber = x.ContactNumber,
                CompanyEmail = x.CompanyEmail,
                RegionId = x.RegionId,
                RegionName = x.Region.RegionName,
                SectorId =x.SectorId,
                SectorName =x.Sector.SectorName,
                IndustryId = x.IndustryId,
                IndustryName = x.Industry.IndustryName,
                UserId = x.UserId,
                EmployerFullName = x.ApplicationUser.FullName,
                DesignationId = x.DesignationId,
                DesignationName = x.Designation.DesignationName,
                CompanyImageId = x.CompanyImageId,
                Companylogo = x.CompanyImage.Image,
                RegistrationDate = x.RegistrationDate
                
            }).ToList();

            return model;
        }

        //Create company details
        public CompanyViewModel GetCompanyDetails(string id)
        {
            Company company = _db.Companies.Where(x => x.CompanyId == id)
                                           .Include(x => x.Sector)
                                           .Include(x => x.Industry)
                                           .Include(x => x.Designation)
                                           .Include(x => x.Region)
                                           .Include(x => x.ApplicationUser)
                                           .Include(x => x.CompanyImage)
                                           .FirstOrDefault();


            CompanyViewModel model = new()
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress,
                CompanyLocation = company.CompanyLocation,
                CompanyRegNo = company.CompanyRegNo,
                CompanyDescription = company.CompanyDescription,
                Companywebsite = company.Companywebsite,
                CompanyVideoLink = company.CompanyVideoLink,
                ContactNumber = company.ContactNumber,
                CompanyEmail = company.CompanyEmail,
                RegionId = company.RegionId,
                RegionName = company.Region.RegionName,
                RegionList = new SelectList(_db.Regions, "RegionId", "RegionName"),
                SectorId = company.SectorId,
                SectorName = company.Sector.SectorName,
                SectorList = new SelectList(_db.Sectors, "SectorId", "SectorName"),
                IndustryId = company.IndustryId,
                IndustryName = company.Industry.IndustryName,
                IndustryList = new SelectList(_db.Industries, "IndustryId", "IndustryName"),
                OtherIndustry = company.OtherIndustry,
                UserId = company.UserId,
                EmployerFullName = company.ApplicationUser.FullName,
                DesignationId = company.DesignationId,
                DesignationList = new SelectList(_db.Designations, "DesignationId", "DesignationName"),
                DesignationName = company.Designation.DesignationName,
                CompanyImageId = company.CompanyImageId,
                Companylogo = company.CompanyImage.Image,
                RegistrationDate = company.RegistrationDate
            };

            return model;
        }

        //Add company
        public bool AddCompany(CompanyViewModel model, ApplicationUser user)
        {
            CompanyLogo logo = new CompanyLogo();
            var userId = user.Id;
            int imageId = 0;
            Guid globalId = Guid.NewGuid();
            string OtherIndustryName;
            if (string.IsNullOrEmpty(model.OtherIndustry))
            {
                OtherIndustryName = "None";
            }
            else
            {
                OtherIndustryName = model.OtherIndustry;
            }

            if(model.ImageIformFile != null)
            {
                byte[] imageByte;
                using (var stream = new MemoryStream())
                {
                    model.ImageIformFile.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
                logo = new CompanyLogo
                {
                    Image = imageByte

                };

                _db.CompanyLogos.Add(logo);
                _db.SaveChanges();
                imageId = logo.CompanyImageId;
                
            }
            Company company = new()
            {
                CompanyId = globalId.ToString(),
                CompanyImageId = imageId,
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                CompanyLocation = model.CompanyLocation,
                CompanyRegNo = model.CompanyRegNo,
                CompanyDescription = model.CompanyDescription,
                Companywebsite = model.Companywebsite,
                CompanyVideoLink = model.CompanyVideoLink,
                ContactNumber = model.ContactNumber,
                CompanyEmail = model.CompanyEmail,
                RegionId = model.RegionId,              
                SectorId = model.SectorId,
                IndustryId = model.IndustryId,
                OtherIndustry = OtherIndustryName,
                UserId = userId,
                DesignationId = model.DesignationId,
                RegistrationDate = DateTime.Now

            };

            _db.Companies.Add(company);
            _db.SaveChanges();

            //Company to be approved or denied by admin
            VerifyCompany verify = new()
            {
                CompanyId = globalId.ToString(),
                VerifyCategoryId = 2
            };
            _db.VerifyCompanies.Add(verify);
            int i = _db.SaveChanges();
            if(i > 0)
            {
                return true;
            }

            return false;

        }

        //update company
        public bool UpdateCompany(CompanyViewModel model,ApplicationUser user)
        {
            var userId = user.Id;
            CompanyLogo logo = new CompanyLogo();
            Company company = new Company();
            if (model.CompanyImageId != null && model.ImageIformFile != null)
            {
                logo = _db.CompanyLogos.Where(x => x.CompanyImageId == model.CompanyImageId).FirstOrDefault();
                byte[] imageByte = new byte[model.ImageIformFile.Length];
                using (var stream = new MemoryStream())
                {
                    model.ImageIformFile.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
                logo.Image = imageByte;
                _db.CompanyLogos.Update(logo);
                _db.SaveChanges();

                company.CompanyImageId = logo.CompanyImageId;

            }

            //else if (model.CompanyImageId == null && model.ImageIformFile != null)
            //{
            //    //in case the company filled the form but didn't upload a logo but is now uploading it
            //    byte[] imageByte;    
            //    using (var stream = new MemoryStream())
            //    {
            //        model.ImageIformFile.CopyTo(stream);
            //        imageByte = stream.ToArray();
            //    }
            //    logo = new CompanyLogo
            //    {
            //        Image = imageByte

            //    };

            //    _db.CompanyLogos.Add(logo);
            //    _db.SaveChanges();
            //    company.CompanyImageId = logo.CompanyImageId;

            //}


          


            string OtherIndustryName;
            if (string.IsNullOrEmpty(model.OtherIndustry))
            {
                OtherIndustryName = "None";
            }
            else
            {
                OtherIndustryName = model.OtherIndustry;
            }

            company = _db.Companies.Where(x => x.CompanyId == model.CompanyId)
                                         .Include(x => x.Sector)
                                         .Include(x => x.Industry)
                                         .Include(x => x.Designation)
                                         .Include(x => x.Region)
                                         .Include(x => x.ApplicationUser)
                                         .Include(x => x.CompanyImage)
                                         .FirstOrDefault();


            company.CompanyId = model.CompanyId;
            company.CompanyName = model.CompanyName;
            company.CompanyAddress = model.CompanyAddress;
            company.CompanyLocation = model.CompanyLocation;
            company.CompanyRegNo = model.CompanyRegNo;
            company.CompanyDescription = model.CompanyDescription;
            company.Companywebsite = model.Companywebsite;
            company.CompanyVideoLink = model.CompanyVideoLink;
            company.ContactNumber = model.ContactNumber;
            company.CompanyEmail = model.CompanyEmail;
            company.RegionId = model.RegionId;
            company.SectorId = model.SectorId;
            company.IndustryId = model.IndustryId;
            company.OtherIndustry = OtherIndustryName;
            company.UserId = userId;
            company.DesignationId = model.DesignationId;
           

            _db.Companies.Update(company);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return true;
            }

            return false;


        }

        //Delete Company

        public bool DeleteCompany(string id)
        {
            
            Company company = _db.Companies.Where(x => x.CompanyId == id).FirstOrDefault();
            _db.Companies.Remove(company);

            //remove logo
            if(company.CompanyImageId != null)
            {
                CompanyLogo companyLogo = _db.CompanyLogos.Where(x => x.CompanyImageId == company.CompanyImageId).FirstOrDefault();
                _db.CompanyLogos.Remove(companyLogo);
            }
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return true;
            }

            return false;
        }

    }
}
