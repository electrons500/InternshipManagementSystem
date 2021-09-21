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
    public class IndustryController : BaseController
    {
        
        private readonly IndustryService _IndustryService;

        public IndustryController(IndustryService industryService)
        {
            _IndustryService = industryService;
        }

        // GET: IndustryController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {            
            
            return View();
        }

        [HttpGet]
         public ActionResult IndustryList()
        {
           // System.Threading.Thread.Sleep(2000);
            var model = _IndustryService.GetIndustries();

            return Json(new { data = model });
        }

        // GET: IndustryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _IndustryService.GetIndustryDetails(id);
            
            return View(model);
        }

        // GET: IndustryController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult AddIndustry()
        {
            return View();
        }

        // POST: IndustryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddIndustry(IndustryViewModel model) 
        {
            try
            {
                bool result = _IndustryService.AddIndustry(model);
                if (result)
                {
                    Alert("Congratulations", "New industry successfully added!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: IndustryController/Edit/5 
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeIndustry(int id)
        {
            var model = _IndustryService.GetIndustryDetails(id);

            return View(model);
        }

        // POST: IndustryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeIndustry(IndustryViewModel model)
        {

            try
            {
                bool result = _IndustryService.UpdateIndustry(model);
                if (result)
                {
                    Alert("Congratulations", "Industry successfully updated!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        

        // POST: IndustryController/Delete/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveIndustry(int Id) 
        {
            try
            {
                bool result = _IndustryService.DeleteIndustry(Id);
                if (result)
                {
                    return Json(new { success = true, message = "Industry successfully deleted!" });
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
