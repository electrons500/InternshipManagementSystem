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
using cloudscribe.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlineInternshipPortal.Controllers
{
    public class InternshipSearchController : Controller
    {

        private readonly InternshipService _internshipService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OnlineInternshipContext _Context;

        public InternshipSearchController(InternshipService internshipService, UserManager<ApplicationUser> userManager, OnlineInternshipContext context)
        {
            _internshipService = internshipService;
            _userManager = userManager;
            _Context = context;
        }

        // GET: InternshipSearchController
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> Index(int? pageNumber, string currentFilter, int IndustryId, string Location ="")
        {
            ViewData["IndustryList"] = new SelectList(_Context.Industries, "IndustryId", "IndustryName");
           
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

            var internships = from s in _Context.Internships.OrderByDescending(x => x.PostedDate)
                                                            .Include(x => x.Publicize)
                                                            .Include(x => x.Industry)
                                                            .Include(x => x.Company)
                                                            .Include(x => x.Remote)
                                                            .Include(x => x.InternshipStatus)
                                                            .Include(x => x.CompanyImage)
                              select s;

            if(IndustryId != 0 && !string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.Location.Contains(Location) && x.IndustryId == IndustryId);
            }else if(IndustryId != 0 && string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.IndustryId == IndustryId); 
            }
            else if(IndustryId == 0 && !string.IsNullOrEmpty(Location))
            {
                internships = internships.Where(x => x.Location.Contains(Location));
            }

            

            int pageSize = 3;

            return View(await PaginatedList<Internship>.CreateAsync(internships.AsNoTracking(),pageNumber ?? 1,pageSize));
           
        }

        // GET: InternshipSearchController/Details/5
        public ActionResult Details(string id)
        {
            var model = _internshipService.GetInternshipDetails(id);
            return View(model);
        }

        // GET: InternshipSearchController/Create
        [HttpGet]
        public async Task<ActionResult> InternshipPosted(int? pageNumber) 
        {
            var user = await _userManager.GetUserAsync(User);
            var company = _Context.Companies.Where(c => c.UserId == user.Id).FirstOrDefault();
            string companyId = company.CompanyId;
            var internships = from s in _Context.Internships.Where(x => x.CompanyId == companyId)
                                                            .OrderByDescending(x => x.PostedDate)
                                                            .Include(x => x.Publicize)
                                                            .Include(x => x.Industry)
                                                            .Include(x => x.Company)
                                                            .Include(x => x.Remote)
                                                            .Include(x => x.InternshipStatus)
                                                            .Include(x => x.CompanyImage)                                                           
                              select s;

            int pageSize = 1;

            return View(await PaginatedList<Internship>.CreateAsync(internships.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        
    }
}
