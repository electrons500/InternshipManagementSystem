using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class InternshipController : BaseController
    {
        private InternshipService _internshipService;
        private readonly UserManager<ApplicationUser> _userManager;
        private OnlineInternshipContext _Context;
        public InternshipController(InternshipService internshipService,UserManager<ApplicationUser> userManager,
            OnlineInternshipContext context
            )
        {
            _internshipService = internshipService;
            _userManager = userManager;
            _Context = context;
        }


        // GET: InternshipController
        [Authorize(Roles = "Employer")]
        public ActionResult Index()
        {
            
            return View();
        }
         public async Task<ActionResult> CompanyInternshipList() 
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _internshipService.GetInternshipsByYourCompany(user);
            return Json(new { data = model });
        }

        // GET: InternshipController/Details/5
        public ActionResult Details(string id)
        {
            var model = _internshipService.GetInternshipDetails(id);
            return View(model);
        }

        // GET: InternshipController/Create
        [Authorize(Roles = "Employer")]
        public async Task<ActionResult> AddInternship()
        {
            var user = await _userManager.GetUserAsync(User);
            int verifyCompanyStatus = CheckIfCompanyHasBeenVerified(user);
            if(verifyCompanyStatus == 1)
            {
                Alert("Company denied", "Company has been denied.Contact adminstrator!", NotificationType.error);
                return RedirectToAction("Employers", "Dashboard");
            }
            else if(verifyCompanyStatus == 2)
            {
                Alert("Verify company", "Your company has not been approved yet", NotificationType.info);
                return RedirectToAction("Employers", "Dashboard");
            }
            else
            {
                var model = _internshipService.CreateInternship();
                return View(model);
            }

           
        }

        // POST: InternshipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddInternship(InternshipViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                

                bool result = _internshipService.AddInternships(model,user);
                if (result)
                {
                    Alert("Congratulations", "New internship successfully posted!", NotificationType.success);
                   
                }
                return RedirectToAction(nameof(Index));
                throw new Exception();
               
            }
            catch
            {
                throw;
            }
        }

        // GET: InternshipController/Edit/5
        [Authorize(Roles = "Employer")] 
        public ActionResult UpdateInternship(string id) 
        {
            var model = _internshipService.GetInternshipDetails(id);
            return View(model);
        }

        // POST: InternshipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInternship(InternshipViewModel model)
        {
            try
            {
                bool result = _internshipService.UpdateInternships(model);
                if (result)
                {
                    Alert("Congratulations", "Internship information successfully updated!", NotificationType.success);

                }
                return RedirectToAction(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: InternshipController/Delete/5
        public ActionResult RemoveInternship(string id)
        {
            var model = _internshipService.GetInternshipDetails(id);
            return View(model);
        }

        // POST: InternshipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveInternship(string id, IFormCollection collection)
        {
            try
            {
                bool result = _internshipService.DeleteInternship(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult InternshipSearch(int industryId)
        //{
        //    var data = _internshipService.SearchForInternships(industryId);
        //    return View(data);

        //}

        private int CheckIfCompanyHasBeenVerified(ApplicationUser user)
        {
            int a;
            Company company = _Context.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            VerifyCompany verifyCompany = _Context.VerifyCompanies.Where(x => x.CompanyId == company.CompanyId).FirstOrDefault();
            int verifyId = verifyCompany.VerifyCategoryId;
            switch (verifyId)
            {
                case 1:
                    a = 1;
                    break;
                case 3:
                    a = 3;
                    break;
                default:
                    a = 2;
                    break;

            }

            return a;
        }

    }
}
