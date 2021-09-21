using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class InternshipService
    {
        private OnlineInternshipContext.OnlineInternshipContext _Context;
        public InternshipService(OnlineInternshipContext.OnlineInternshipContext context)
        {
            _Context = context;
        }

        //Dropdowns
        public InternshipViewModel CreateInternship()
        {
            InternshipViewModel model = new()
            {
                InternshipStatusList = new SelectList(_Context.InternshipStatuses, "InternshipStatusId","Name"),
                RemoteList =new SelectList(_Context.Remotes, "RemoteId","Name"),
                PublicizeList = new SelectList(_Context.Publicizes, "PublicizeId","Name"),
                IndustryList = new SelectList(_Context.Industries, "IndustryId", "IndustryName")
            };

            return model;
        }

        //List of a company's internship posted
        public List<InternshipViewModel> GetInternshipsByYourCompany(ApplicationUser user) 
        {
            var company = _Context.Companies.Where(c => c.UserId == user.Id).FirstOrDefault();
            string companyId = company.CompanyId;
            List<Internship> internships = _Context.Internships.Include(x => x.Publicize)
                                                               .Include(x => x.Industry)
                                                               .Include(x => x.Company)
                                                               .Include(x => x.Remote)
                                                               .Include(x => x.InternshipStatus)
                                                               .Include(x => x.CompanyImage)
                                                               .Where(x => x.CompanyId == companyId ) //select internship by login company
                                                               .ToList();
            List<InternshipViewModel> model = internships.Select(x => new InternshipViewModel
            {
                InternshipId = x.InternshipId,
                Title = x.Title,
                Location = x.Location, 
                Duration = x.Duration,
                WorkDescription = x.WorkDescription,
                SkillsRequired = x.SkillsRequired,
                AdditionalInfo = x.AdditionalInfo,
                DeadLineDate = x.DeadLineDate,
                WhoCanApply = x.WhoCanApply,
                PostedDate = x.PostedDate,
                PostedTime = x.PostedTime,
                
                //for the dropdowns
                InternshipStatusId = x.InternshipStatusId,
                InternshipStatusName = x.InternshipStatus.Name,

                RemoteId = x.RemoteId,
                RemoteName = x.Remote.Name,

                PublicizeId = x.PublicizeId,
                PublicizeName = x.Publicize.Name,

                IndustryId = x.IndustryId,
                IndustryName = x.Industry.IndustryName,

                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CompanyImageId = x.CompanyImageId,
                Companylogo = x.CompanyImage.Image
                

            }).ToList();


            return model;

        }

        //Internship details
        public InternshipViewModel GetInternshipDetails(string id)
        {
            Internship Internships = _Context.Internships.Where(x => x.InternshipId == id).Include(x => x.Publicize)
                                                                                 .Include(x => x.Industry)
                                                                                 .Include(x => x.Company)
                                                                                 .Include(x => x.Remote)
                                                                                 .Include(x => x.InternshipStatus)
                                                                                 .Include(x => x.CompanyImage)
                                                                                 .FirstOrDefault();
            InternshipViewModel model = new()
            {
                InternshipId = Internships.InternshipId,
                Title = Internships.Title,
                Duration = Internships.Duration,
                WorkDescription = Internships.WorkDescription,
                SkillsRequired = Internships.SkillsRequired,
                AdditionalInfo = Internships.AdditionalInfo,
                DeadLineDate = Internships.DeadLineDate,
                WhoCanApply = Internships.WhoCanApply,
                PostedDate = Internships.PostedDate,
                PostedTime = Internships.PostedTime,
                Location = Internships.Location,
                //for the dropdowns
                InternshipStatusId = Internships.InternshipStatusId,
                InternshipStatusName = Internships.InternshipStatus.Name,
                InternshipStatusList = new SelectList(_Context.InternshipStatuses, "InternshipStatusId", "Name"),

                RemoteId = Internships.RemoteId,
                RemoteName = Internships.Remote.Name,

                PublicizeId = Internships.PublicizeId,
                PublicizeName = Internships.Publicize.Name,

                IndustryId = Internships.IndustryId,
                IndustryName = Internships.Industry.IndustryName,

                CompanyId = Internships.CompanyId,
                CompanyName = Internships.Company.CompanyName,
                CompanyImageId = Internships.CompanyImageId,
                Companylogo = Internships.CompanyImage.Image,

                RemoteList = new SelectList(_Context.Remotes, "RemoteId", "Name"),
                PublicizeList = new SelectList(_Context.Publicizes, "PublicizeId", "Name"),
                IndustryList = new SelectList(_Context.Industries, "IndustryId", "IndustryName")


            };

            return model;
        }

        //Add Internship  
        public bool AddInternships(InternshipViewModel model,ApplicationUser user)
        {
            var company = _Context.Companies.Where(c => c.UserId == user.Id).FirstOrDefault();
            string companyId = company.CompanyId;
            int? imageId = company.CompanyImageId;
            Guid guid = Guid.NewGuid();
            string intershipId = guid.ToString();
            //When  you wake up Create a GUID for internshipId.DB is not auto increment


            Internship internship = new()
            {              
               InternshipId = intershipId, 
                Title = model.Title,
                Location = model.Location, 
                Duration = model.Duration,
                WorkDescription = model.WorkDescription,
                SkillsRequired = model.SkillsRequired,
                AdditionalInfo = model.AdditionalInfo,
                DeadLineDate = model.DeadLineDate,
                WhoCanApply = model.WhoCanApply,
                PostedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                PostedTime = DateTime.Now.ToShortTimeString(),

                //for the dropdowns
                InternshipStatusId = model.InternshipStatusId,
                RemoteId = model.RemoteId,
                PublicizeId = model.PublicizeId,
                IndustryId = model.IndustryId,
                CompanyId = companyId,
                CompanyImageId = imageId

            };

            _Context.Internships.Add(internship);
            _Context.SaveChanges();

            return true;

        }

        //update data
        public bool UpdateInternships(InternshipViewModel model)
        {
            Internship internships = _Context.Internships.Where(x => x.InternshipId == model.InternshipId).Include(x => x.Publicize)
                                                                                .Include(x => x.Industry)
                                                                                .Include(x => x.Company)
                                                                                .Include(x => x.Remote)
                                                                                .Include(x => x.InternshipStatus)
                                                                                .Include(x => x.CompanyImage)
                                                                                .FirstOrDefault();

            internships.Title = model.Title;
            internships.Location = model.Location;
            internships.Duration = model.Duration;
            internships.WorkDescription = model.WorkDescription;
            internships.SkillsRequired = model.SkillsRequired;
            internships.AdditionalInfo = model.AdditionalInfo;
            internships.DeadLineDate = model.DeadLineDate;
            internships.WhoCanApply = model.WhoCanApply;
          
            //for the dropdowns
            internships.InternshipStatusId = model.InternshipStatusId;
            internships.RemoteId = model.RemoteId;
            internships.PublicizeId = model.PublicizeId;
            internships.IndustryId = model.IndustryId;
            internships.PostedDate = model.PostedDate;
           

            _Context.Internships.Update(internships);
            _Context.SaveChanges();

            return true;


        }

        //Delete
        public bool DeleteInternship(string id)
        {
            Internship internships = _Context.Internships.Where(x => x.InternshipId == id).Include(x => x.Publicize)
                                                                               .Include(x => x.Industry)
                                                                               .Include(x => x.Company)
                                                                               .Include(x => x.Remote)
                                                                               .Include(x => x.InternshipStatus)
                                                                               .Include(x => x.CompanyImage)
                                                                               .FirstOrDefault();


            _Context.Internships.Remove(internships);
            _Context.SaveChanges();


            return true;


        }


        //for Admin only to see all internhips from all registered companies
        public List<InternshipViewModel> GetAllInternships(int pageNumber,int pageSize) 
        {
            //for paging
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            List<Internship> internships = _Context.Internships.OrderByDescending( x => x.PostedDate)
                                                               .Include(x => x.Publicize)
                                                               .Include(x => x.Industry)
                                                               .Include(x => x.Company)
                                                               .Include(x => x.Remote)
                                                               .Include(x => x.InternshipStatus)
                                                               .Include(x => x.CompanyImage)
                                                               .Skip(ExcludeRecords)
                                                               .Take(pageSize)
                                                               .ToList();

            List<InternshipViewModel> model = internships.Select(x => new InternshipViewModel
            {
                InternshipId = x.InternshipId,
                Title = x.Title,
                Duration = x.Duration,
                Location = x.Location,
                WorkDescription = x.WorkDescription,
                SkillsRequired = x.SkillsRequired,
                AdditionalInfo = x.AdditionalInfo,
                DeadLineDate = x.DeadLineDate,
                WhoCanApply = x.WhoCanApply,
                PostedDate = x.PostedDate,
                PostedTime = x.PostedTime,

                //for the dropdowns
                InternshipStatusId = x.InternshipStatusId,
                InternshipStatusName = x.InternshipStatus.Name,

                RemoteId = x.RemoteId,
                RemoteName = x.Remote.Name,

                PublicizeId = x.PublicizeId,
                PublicizeName = x.Publicize.Name,

                IndustryId = x.IndustryId,
                IndustryName = x.Industry.IndustryName,

                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CompanyImageId = x.CompanyImageId,
                Companylogo = x.CompanyImage.Image


            }).ToList();


            return model;

        }

        //for students to search for internship by the industryId and date by 1 week,2 weeks,1 month and beyond

        public List<InternshipViewModel> SearchForInternships(int pageSize,int pageNumber,string Location)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            List<Internship> internships = _Context.Internships.Where(x => x.Location.Contains(Location))
                                                               .OrderByDescending(x => x.PostedDate)
                                                               .Include(x => x.Publicize)
                                                               .Include(x => x.Industry)
                                                               .Include(x => x.Company)
                                                               .Include(x => x.Remote)
                                                               .Include(x => x.InternshipStatus)
                                                               .Include(x => x.CompanyImage)
                                                               
                                                               .ToList();
            

            List<InternshipViewModel> model = internships.Select(x => new InternshipViewModel
            {
                               
                InternshipId = x.InternshipId,
                Title = x.Title,
                Duration = x.Duration,
                Location = x.Location,
                WorkDescription = x.WorkDescription,
                SkillsRequired = x.SkillsRequired,
                AdditionalInfo = x.AdditionalInfo,
                DeadLineDate = x.DeadLineDate,
                WhoCanApply = x.WhoCanApply,
                PostedDate = x.PostedDate,
                PostedTime = x.PostedTime,

                //for the dropdowns
                InternshipStatusId = x.InternshipStatusId,
                InternshipStatusName = x.InternshipStatus.Name,

                RemoteId = x.RemoteId,
                RemoteName = x.Remote.Name,

                PublicizeId = x.PublicizeId,
                PublicizeName = x.Publicize.Name,

                IndustryId = x.IndustryId,
                IndustryName = x.Industry.IndustryName,

                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CompanyImageId = x.CompanyImageId,
                Companylogo = x.CompanyImage.Image


            }).ToList();

            
            return model;

        }

    }
}
