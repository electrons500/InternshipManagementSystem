using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class ApplicatonService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;

        public ApplicatonService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //Check if vlaues(Yes and No) exist in the table IntershipApproval by counting them
        private int CheckIfInternshipApprovalValuesExist()
        {
            int internshipapprovalcount = _db.InternshipApprovals.Count();
            int rowsAffected;
            if (internshipapprovalcount == 0)
            {
                InternshipApproval approvalOne = new InternshipApproval
                {
                    Name = "Approved"
                };
                _db.InternshipApprovals.Add(approvalOne);
                _db.SaveChanges();
                InternshipApproval ApprovalTwo = new InternshipApproval
                {
                    Name = "Pending"
                };
                _db.InternshipApprovals.Add(ApprovalTwo);
                _db.SaveChanges();
                InternshipApproval ApprovalThree = new InternshipApproval
                {
                    Name = "Denied"
                };
                _db.InternshipApprovals.Add(ApprovalThree);
                _db.SaveChanges();

                rowsAffected = 3;
            }
            else
            {
                rowsAffected = internshipapprovalcount;
            }

            return rowsAffected;

        }


        //Add new applications from students
        public bool AddApplications(ApplicationUser user, string internshipId)
        {
            if (CheckIfInternshipApprovalValuesExist() > 0)
            {
                Guid guid = Guid.NewGuid();
                var InternInfo = _db.Interns.Where(x => x.Email == user.Email).FirstOrDefault();
                string applicationId = guid.ToString();
                var internshipInfo = _db.Internships.Where(x => x.InternshipId == internshipId).FirstOrDefault();
                Application userapplication = new()
                {
                    ApplicationId = applicationId,
                    InternshipId = internshipId,
                    InternId = InternInfo.InternId,
                    CompanyId = internshipInfo.CompanyId,
                    CvId = InternInfo.CvId,
                    DateOfRegistration = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    ApprovalId = 2
                };
                _db.Applications.Add(userapplication);
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }


        }

        //Hirer must approve or deny the person by updating applications received
        public bool ApproveORdenyApplicant(ApplicationViewModel model)
        {
            Application application = _db.Applications.Where(x => x.ApplicationId == model.ApplicationId).FirstOrDefault();
            application.ApprovalId = model.ApprovalId;
            _db.Applications.Update(application);
            _db.SaveChanges();

            return true;

        }

        //create user approval
        public ApplicationViewModel CreateUserApproval()
        {
            ApplicationViewModel model = new()
            {
                ApprovalList = new SelectList(_db.InternshipApprovals, "ApprovalId", "Name")
            };

            return model;
        }

        //students who have applied to a specific company
        public List<ApplicationViewModel> GetApplicantsOfSpecificCompany(ApplicationUser user)
        {
            var company = _db.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            List<Application> applications = _db.Applications.Where(x => x.CompanyId == company.CompanyId)
                                                             .Include(x => x.Intern)
                                                             .Include(x => x.Internship)
                                                             .Include(x => x.Company)
                                                             .Include(x => x.Cv)
                                                             .Include(x => x.Approval)
                                                             .ToList();

            List<ApplicationViewModel> model = applications.Select(x => new ApplicationViewModel
            {
                ApplicationId = x.ApplicationId,
                InternId = x.InternId,
                InternName = x.Intern.FullName,
                InternshipId = x.InternshipId,
                InternshipTitle = x.Internship.Title,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CvId = x.CvId,
                CvName = x.Cv.Filename,
                DateOfApplication = x.DateOfRegistration,
                ApprovalId = x.ApprovalId,
                ApprovalName = x.Approval.Name,


            }).ToList();


            return model;

        }

        //for admin to see all applicants who have applied to companies
        public List<ApplicationViewModel> GetApplicantsOfAllCompany()
        {

            List<Application> applications = _db.Applications.OrderByDescending(x => x.DateOfRegistration)
                                                             .Include(x => x.Intern)
                                                             .Include(x => x.Internship)
                                                             .Include(x => x.Company)
                                                             .Include(x => x.Cv)
                                                             .Include(x => x.Approval)
                                                             .ToList();

            List<ApplicationViewModel> model = applications.Select(x => new ApplicationViewModel
            {
                ApplicationId = x.ApplicationId,
                InternId = x.InternId,
                InternName = x.Intern.FullName,
                InternshipId = x.InternshipId,
                InternshipTitle = x.Internship.Title,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CvId = x.CvId,
                CvName = x.Cv.Filename,
                DateOfApplication = x.DateOfRegistration,
                ApprovalId = x.ApprovalId,
                ApprovalName = x.Approval.Name,

            }).ToList();


            return model;

        }

        //Student or intern viewinglist of his/her applications sent
        public List<ApplicationViewModel> GetApplicationSentByStudent(ApplicationUser user)
        {
            var interns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).FirstOrDefault();
            List<Application> applications = _db.Applications.Where(x => x.InternId == interns.InternId)
                                                             .OrderByDescending(x => x.DateOfRegistration)
                                                             .Include(x => x.Intern)
                                                             .Include(x => x.Internship)
                                                             .Include(x => x.Company)
                                                             .Include(x => x.Cv)
                                                             .Include(x => x.Approval)
                                                             .ToList();

            List<ApplicationViewModel> model = applications.Select(x => new ApplicationViewModel
            {
                ApplicationId = x.ApplicationId,
                InternId = x.InternId,
                InternName = x.Intern.FullName,
                InternshipId = x.InternshipId,
                InternshipTitle = x.Internship.Title,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CvId = x.CvId,
                CvName = x.Cv.Filename,
                DateOfApplication = x.DateOfRegistration,
                ApprovalId = x.ApprovalId,
                ApprovalName = x.Approval.Name,


            }).ToList();


            return model;
        }

        //Student deleting his/her application
        public bool DeleteApplication(string id)
        {
            Application application = _db.Applications.Where(x => x.ApplicationId == id).FirstOrDefault();
            _db.Applications.Remove(application);
           int i = _db.SaveChanges();
            if(i > 0)
            {
                return true;
            }

            return false;
        }

        //Application details for admin
        public ApplicationViewModel GetApplicationDetails(string id)
        {
            Application application = _db.Applications.Where(x => x.ApplicationId == id)
                                                       .Include(x => x.Intern)
                                                       .Include(x => x.Internship)
                                                       .Include(x => x.Company)
                                                       .Include(x => x.Cv)
                                                       .Include(x => x.Approval)
                                                      .FirstOrDefault();

            ApplicationViewModel model = new()
            {
                ApplicationId = application.ApplicationId,
                InternId = application.InternId,
                InternName = application.Intern.FullName,
                InternshipId = application.InternshipId,
                InternshipTitle = application.Internship.Title,
                CompanyId = application.CompanyId,
                CompanyName = application.Company.CompanyName,
                CvId = application.CvId,
                CvName = application.Cv.Filename,
                DateOfApplication = application.DateOfRegistration,
                ApprovalId = application.ApprovalId,
                ApprovalName = application.Approval.Name,
            };

            return model;

        }


    }
}
