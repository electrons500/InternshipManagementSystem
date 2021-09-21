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
    public class DesignationController : BaseController
    {
        private DesignationService _DesignationService;
        public DesignationController(DesignationService designationservice)
        {
            _DesignationService = designationservice;
        }
        
        // GET: DesignationController
        public ActionResult Index()
        {          
            return View();
        }

        [HttpGet]
        public ActionResult DesignationList()
        {
            var model = _DesignationService.GetDesignations();
            return Json(new { data = model });
        }

        // GET: DesignationController/Details/5
        public ActionResult Details(int id)
        {
            var model = _DesignationService.GetDesignationDetails(id);
            return View(model);
        }

        // GET: DesignationController/Create
        public ActionResult AddDesignation() 
        {
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDesignation(DesignationViewModel model)
        {
            try
            {
                bool result = _DesignationService.AddDesignation(model);
                if(result == true)
                {
                    Alert("Congratulations", "New designation successfully added!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }
               throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Edit/5
        public ActionResult ChangeDesignation(int id) 
        {
            var model = _DesignationService.GetDesignationDetails(id);
            return View(model);
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDesignation(DesignationViewModel model) 
        {
            try
            {
                bool result = _DesignationService.UpdateDesignation(model);
                if (result)
                {
                    Alert("Congratulations", "Designation successfully updated!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // POST: DesignationController/Delete/5
       [HttpDelete]
        public ActionResult RemoveDesignation(int id) 
        {
            try
            {
                bool result = _DesignationService.DeleteDesignation(id);
                if (result)
                {
                    return Json(new { success = true, message = "Designation successfully deleted!" });
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
