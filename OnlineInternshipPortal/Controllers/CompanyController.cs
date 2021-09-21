using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class CompanyController : BaseController
    {
        private CompanyService _CompanyService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanyController(CompanyService companyService, UserManager<ApplicationUser> userManager)
        {
            _CompanyService = companyService;
            _userManager = userManager;
        }

        // GET: CompanyController
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult CompanyList()
        {
            var model = _CompanyService.GetCompanies();
            return Json(new { data = model });
        }


        [HttpGet]
        [Authorize(Roles = "Employer")]
        public async Task<ActionResult> CompanyInformation()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _CompanyService.CompanyInformation(user);
            return View(model);
        }


        // GET: CompanyController/Details/5
     
        public ActionResult CompanyDetails(string id)
        {

            var model = _CompanyService.GetCompanyDetails(id);
            if (model.OtherIndustry == "None")
            {
                ViewData["OtherIndustry"] = "1";
            }
            return View(model);
        }

        // GET: CompanyController/Create
        [Authorize(Roles = "Employer")]
        public async Task<ActionResult> AddCompany()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _CompanyService.CreateCompany(user);
            return View(model);
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCompany(CompanyViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            try
            {
                bool result = _CompanyService.AddCompany(model, user);
                if (result)
                {
                    Alert("Congratulations", "New company successfully added!", NotificationType.success);   
                }
                return RedirectToAction("Employers","Dashboard");
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        [Authorize(Roles = "Employer")]
        public ActionResult ChangeCompanyDetails(string id)
        {
            var model = _CompanyService.GetCompanyDetails(id);
            if (model.OtherIndustry == "None")
            {
                ViewData["OtherIndustry"] = "1";
            }

            return View(model);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeCompanyDetails(CompanyViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            try
            {
                bool result = _CompanyService.UpdateCompany(model, user);
                if (result)
                {
                    Alert("Congratulations", "Company information successfully updated!", NotificationType.success);
                  
                }
                return RedirectToAction(nameof(CompanyInformation));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }


        // POST: CompanyController/Delete/5
        [HttpDelete]
        public ActionResult Removecompany(string id)
        {
            try
            {
                bool result = _CompanyService.DeleteCompany(id);
                if (result)
                {
                    return Json(new { success = true, message = "Data successfully deleted!" });
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        //


    }
}
