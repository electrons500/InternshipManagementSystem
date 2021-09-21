using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class InternsController : BaseController
    {

        private readonly InternService _internService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OnlineInternshipContext _db;

        public InternsController(InternService internService, UserManager<ApplicationUser> userManager, OnlineInternshipContext db)
        {
            _internService = internService;
            _userManager = userManager;
            _db = db;
        }

        // GET: InternsController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
         public ActionResult InternsList()
        {
            var model = _internService.GetInterns();
            return Json(new { data = model });
        }

        // GET: InternsController/Details/5
        public ActionResult InternDetails(string id)
        {
            var model = _internService.GetInternsDetails(id);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> StudentDetails()
        {
            var user = await _userManager.GetUserAsync(User); // Get students credentials
            int Countinterns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Count();
           
            if(Countinterns == 0)
            {
                Alert("Sorry", "Add your student information first before you can view student information", NotificationType.error);
                return RedirectToAction("Students", "Dashboard");
            }
            else
            {
                var model = _internService.GetStudentDetails(user);
                return View(model);
            }
           
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> UpdateStudentDetails()  
        {
            var user = await _userManager.GetUserAsync(User); // Get students credentials
            int Countinterns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Count();

            if (Countinterns == 0)
            {
                Alert("Sorry", "Add your student information first before you can edit student information", NotificationType.error);
                return RedirectToAction("Students", "Dashboard");
            }
            else
            {
                var model = _internService.GetStudentDetails(user);
                return View(model);
            }
        }



        // GET: InternsController/Create
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> AddInterns()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _internService.CreateInterns(user);
            return View(model);
        }

        // POST: InternsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddInterns(InternsViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (CheckIfInternInformationAlreadyExist(user)) //if true then user has already filled intern information
                {
                    Alert("Sorry", "Intern information already exist", NotificationType.error);
                }
                else
                {
                    bool result = _internService.AddInterns(model);
                    if (result)
                    {
                        //sweet alert
                        Alert("Congratulations", "Intern information successfully added!", NotificationType.success);
                    }

                }

                return RedirectToAction("Students", "Dashboard");
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: InternsController/Edit/5
        public ActionResult UpdateInterns(string id) 
        {
            var model = _internService.GetInternsDetails(id);
            return View(model);
        }

        // POST: InternsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInterns(InternsViewModel model)
        {
            try
            {
                
                bool result = _internService.UpdateInterns(model);
                if (result)
                {
                    Alert("Congratulations", "Intern information successfully updated!", NotificationType.success);                  
                }
                return RedirectToAction("Students", "Dashboard");
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: InternsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Check if Intern already added his/her intern information.Intern cannot fill two intern forms and upload two or mor CVs
        private bool CheckIfInternInformationAlreadyExist(ApplicationUser user)
        {
            int internCount = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Count();
            if(internCount > 0)
            {
                return true;
            }

            return false;
        }

    }
}
