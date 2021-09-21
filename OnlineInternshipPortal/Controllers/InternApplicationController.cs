using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class InternApplicationController : BaseController
    {
        private ApplicatonService _applicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly InternService _internService;
        private readonly OnlineInternshipContext _db;
        string companyNo;
        string internNo;

        public InternApplicationController(ApplicatonService applicationService, UserManager<ApplicationUser> userManager, InternService internService,
            OnlineInternshipContext db
            )
        {
            _applicationService = applicationService;
            _userManager = userManager;
            _internService = internService;
            _db = db;
        }

        // GET: InternApplicationController
        public ActionResult Index()
        {
            var model = _applicationService.CreateUserApproval();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> InternApplicationList()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _applicationService.GetApplicantsOfSpecificCompany(user);

            return Json(new { data = model });

        }

        // GET: InternApplicationController/Details/5
        public ActionResult InternInformation(string id)
        {
            var model = _internService.GetInternsDetails(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InternInformation(ApplicationViewModel model)
        {
            //var applicationId = Request.Form["txtapplicationId"].ToString(); 
            //var Approval = Request.Form["dropdownlistApproval"].ToString(); 
            int approvalId = model.ApprovalId;

            try
            {
                bool result = _applicationService.ApproveORdenyApplicant(model);
                if (result)
                {
                    switch (approvalId)
                    {
                        case 1:

                            //if applicant is approve then send his id and companyId to hired table
                            bool hiredResult = HireApplicant(model.ApplicationId);
                            if (hiredResult)
                            {
                                Alert("Congratulations", "Applicant has been successfully approved!", NotificationType.success);
                            }
                            else
                            {
                                Alert("Error", "Applicant has already been hired!", NotificationType.error);
                            }
                            break;
                        case 2:
                            Alert("Question", "Applicant is still under pending why?", NotificationType.warning); 
                            break;
                        default:
                            Alert("Congratulations", "Applicant has been successfully denied!", NotificationType.success);
                            break;

                    }


                    return RedirectToAction("Index");
                }
                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> ApplyInternship(string id)
        {
            try
            {

                var user = await _userManager.GetUserAsync(User);
                //A check to ensure that a student don't apply a particular internship more than one.
                if(CheckIfStudentHasAppliedSpecificInternshipMoreThanOne(user,id) == 0)
                {
                    bool result = _applicationService.AddApplications(user, id);
                    if (result)
                    {
                        //display sweet alert of success and redirect back to Internship search index
                        Alert("Congratulations", "You have successfully applied for the internship!", NotificationType.success);
                    }
                    else
                    {
                        Alert("Error", "Your application failed to apply", NotificationType.error);

                    }
                }
                else
                {
                    Alert("Error", "You have already applied for this internship", NotificationType.error);
                }


                return RedirectToAction("Index", "InternshipSearch");
                throw new Exception();
            }
            catch
            {
                // return View();
                throw;
            }
        }

        //check if applicant is already hired by the same company
        private int CheckIfApplicantHasBeenHiredByTheSameCompany(string applicationId)
        {
            var ApplicantApplication = _db.Applications.Where(x => x.ApplicationId == applicationId).FirstOrDefault();
            companyNo = ApplicantApplication.CompanyId;
            internNo = ApplicantApplication.InternId;
            int applicantCount = _db.Hireds.Where(x => x.InternId == ApplicantApplication.InternId && x.CompanyId == ApplicantApplication.CompanyId).Count();

            return applicantCount;
        }

        //After checking if applicant is already hired by the same company,
        //if applicant has not been hired then hire him/her else show an alert of applicant already hired
        public bool HireApplicant(string applicationId)
        {
            if (CheckIfApplicantHasBeenHiredByTheSameCompany(applicationId) > 0)
            {
                return false; // applicant has already been hired
            }
            else
            {
                //if equals zero then
                Hired hired = new()
                {
                    InternId = internNo,
                    CompanyId = companyNo,
                    HireDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())

                };
                _db.Hireds.Add(hired);
                _db.SaveChanges();

                return true;
            }
        }

        //student/Intern able to view list of all internship applied
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> StudentApplications()
        {
            var user = await _userManager.GetUserAsync(User);
            int Countinterns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Count();

            if (Countinterns == 0)
            {
                Alert("Sorry", "Please add your student information first", NotificationType.error);
                return RedirectToAction("Students", "Dashboard");
            }
            else
            {
                return View();
            }
           
        }

         [HttpGet]
        public async Task<ActionResult> StudentApplicationsList()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _applicationService.GetApplicationSentByStudent(user);

            return Json(new { data = model });
        }

        [HttpDelete]
        public ActionResult DeleteApplicationSent(string id)
        {
            try
            {
                bool result = _applicationService.DeleteApplication(id);
                if (result)
                {
                    return Json(new { success = true, message = "Application successfully deleted!" });

                }
                else
                {
                    Alert("Error", "Application sent failed to delete", NotificationType.error);
                }
              

                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int CheckIfStudentHasAppliedSpecificInternshipMoreThanOne(ApplicationUser user,string internshipId)
        {
            Intern intern = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).FirstOrDefault();
            int applicationCount = _db.Applications.Where(x => x.InternId == intern.InternId && x.InternshipId == internshipId).Count();
            return applicationCount;
        }

    }
}
