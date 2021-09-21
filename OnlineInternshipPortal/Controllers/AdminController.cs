using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly AccountRegistrationService _accountRegistrationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private OnlineInternshipContext _db;
        private CompanyService _CompanyService;
        private InternshipService _internshipService;
        private readonly InternService _internService;
        private ApplicatonService _applicationService;
        public AdminController(OnlineInternshipContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            AccountRegistrationService accountRegistrationService, CompanyService companyService, InternshipService internshipService, InternService internService, ApplicatonService applicationService)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountRegistrationService = accountRegistrationService;
            _CompanyService = companyService;
            _internshipService = internshipService;
            _internService = internService;
            _applicationService = applicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Companies() 
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult CompaniesList() 
        {
            var model = _CompanyService.GetCompanies();
            return Json(new { data = model });
        }

        //Company details
        [Authorize(Roles = "Admin")]
        public ActionResult CompanyDetails(string id)
        {

            var model = _CompanyService.GetCompanyDetails(id);
            if (model.OtherIndustry == "None")
            {
                ViewData["OtherIndustry"] = "1";
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Internships(int? pageNumber, string currentFilter, int IndustryId, string Location = "")
        {


            ViewData["IndustryList"] = new SelectList(_db.Industries, "IndustryId", "IndustryName");

            if (IndustryId != 0 && !string.IsNullOrEmpty(Location))
            {
                pageNumber = 1;
            }
            else if (IndustryId != 0 && string.IsNullOrEmpty(Location))
            {
                pageNumber = 1;
            }
            else if (IndustryId == 0 && !string.IsNullOrEmpty(Location))
            {
                pageNumber = 1;
            }
            else
            {
                Location = currentFilter;
            }

            ViewData["CurrentFilter"] = Location;

            var internships = from s in _db.Internships.OrderByDescending(x => x.PostedDate)
                                                            .Include(x => x.Publicize)
                                                            .Include(x => x.Industry)
                                                            .Include(x => x.Company)
                                                            .Include(x => x.Remote)
                                                            .Include(x => x.InternshipStatus)
                                                            .Include(x => x.CompanyImage)
                              select s;

            if (IndustryId != 0 && !string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.Location.Contains(Location) && x.IndustryId == IndustryId);
            }
            else if (IndustryId != 0 && string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.IndustryId == IndustryId);
            }
            else if (IndustryId == 0 && !string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.Location.Contains(Location));
            }



            int pageSize = 5;

            return View(await PaginatedList<Internship>.CreateAsync(internships.AsNoTracking(), pageNumber ?? 1, pageSize));


        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult InternshipDetails(string id) 
        {
            var model = _internshipService.GetInternshipDetails(id);
            return View(model);
        }

          [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult InternsDetails(string id)  
        {
            
            var model = _internService.GetInternsDetails(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InternsApplications()
        {
            return View();
        }
        [HttpGet] 
        public ActionResult InternsApplicationsList() 
        {
            var model = _applicationService.GetApplicantsOfAllCompany();

            return Json(new { data = model });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult InternsApplicationsDetails(string id) 
        {
            var model = _applicationService.GetApplicationDetails(id);

            return View(model);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveInternsApplication(string id)
        {
            try
            {
                bool result = _applicationService.DeleteApplication(id);
                if (result)
                {
                    return Json(new { success = true, message = "Intern Application successfully deleted!" });
                }

                throw new Exception();
            }
            catch (Exception)
            {

                return View();
            }
        }

        //


    }
}
