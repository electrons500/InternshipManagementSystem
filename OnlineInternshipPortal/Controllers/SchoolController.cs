using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            this._schoolService = schoolService;
        }

        // GET: SchoolController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult SchoolList() 
        {
            var model = _schoolService.GetSchools();
            return Json(new { data = model });
        }



        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchoolController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult AddSchool()
        {
            return View();
        }

        // POST: SchoolController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSchool(SchoolViewModel model) 
        {
            try
            {
                bool result = _schoolService.AddSchool(model);
                if (result)
                {
                    Alert("Congratulations", "New school successfully added!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }
               throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditSchool(int id)
        {
            var model = _schoolService.GetSchoolDetails(id);
            return View(model);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSchool(SchoolViewModel model)
        {
            try
            {
                bool result = _schoolService.UpdateSchool(model);
                if (result)
                {
                    Alert("Congratulations", "School successfully updated!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSchool(int id)
        {
            try
            {
                bool result = _schoolService.DeleteSchool(id);
                if (result)
                {
                    return Json(new { success = true, message = "School successfully deleted!" });
                    
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

      
       
    }
}
