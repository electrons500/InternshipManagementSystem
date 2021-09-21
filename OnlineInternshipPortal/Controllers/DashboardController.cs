using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private OnlineInternshipContext _db;

        public DashboardController(UserManager<ApplicationUser> userManager, OnlineInternshipContext db)
        {
            _userManager = userManager;
            _db = db;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        //Admin dashboard
        [Authorize(Roles ="Admin")]
        public IActionResult Admins()
        {
            int countUsers = _db.Users.Count();
            ViewData["NumnberOfUsers"] = countUsers;

            int countCompanies = _db.Companies.Count();
            ViewData["NumnberOfCompanies"] = countCompanies;

            int countInterns = _db.Interns.Count();
            ViewData["NumberOfInterns"] = countInterns;

            int countInternships = _db.Internships.Count();
            ViewData["NumberOfInternships"] = countInternships;

            int countPendingCompanies = _db.VerifyCompanies.Where(x => x.VerifyCategoryId == 2).Count();
            ViewData["countPendingCompanies"] = countPendingCompanies;

            return View();
        }

        [HttpPost]
        public IActionResult Admins(IFormCollection collections)
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Students()
        {
            var user = await _userManager.GetUserAsync(User);
            int countUnreadMessages = GetNumberOfUnReadMessages(user);
            if ( countUnreadMessages > 0)
            {
                Alert("New Messages", "You have " + countUnreadMessages + " new messages!", NotificationType.info);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Students(IFormCollection collections)
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public IActionResult Employers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employers(IFormCollection collections)
        {

            return View();
        }


        //check number student unread messages
        private int GetNumberOfUnReadMessages(ApplicationUser user)
        {
            int countUnreadMSG = 0;
            Intern intern = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).FirstOrDefault();

            if(intern == null)
            {
                countUnreadMSG = 0;
            }
            else
            {
                countUnreadMSG = _db.RecievedMsgFromCompanies.Where(x => x.InternId == intern.InternId && x.MsgReadStatusId == 1).Count();
            }

            return countUnreadMSG;
        }

    }
}
