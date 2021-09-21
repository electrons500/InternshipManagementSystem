using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Controllers
{
    public class VerifyCompanyController : Controller
    {
        private readonly VerifyCompanyService _verifyCompanyService;
        private OnlineInternshipContext _db;
        public VerifyCompanyController(VerifyCompanyService verifyCompanyService,OnlineInternshipContext db)
        {
            _verifyCompanyService = verifyCompanyService;
            _db = db;
        }

        [Authorize(Roles = "Admin")]
        // GET: VerifyCompanyController
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
         public ActionResult VerifyPendingCompanyList()
        {
            var model = _verifyCompanyService.GetPendingCompanies();
            return Json(new { data = model });
        }


        //Verify approved companies
        [Authorize(Roles = "Admin")]
        public ActionResult ApprovedCompanies()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VerifyApprovedCompanyList()
        {
            var model = _verifyCompanyService.GetApprovedCompanies();
            return Json(new { data = model });
        }


        [Authorize(Roles = "Admin")]
        public ActionResult DeniedCompanies()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VerifyDeniedCompanyList() 
        {
            var model = _verifyCompanyService.GetDeniedCompanies();
            return Json(new { data = model });
        }



        // POST: VerifyCompanyController/Edit/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult ApproveCompany(string id)
        {
            try
            {
                int verifyId = 3;
                bool result = _verifyCompanyService.UpdateVerifyCompanyWithoutEF(id,verifyId);
                if (result)
                {
                    return Json(new { success = true, message = "Company has been approved!" });
                }
                throw new Exception();
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult DenyCompany(string id)
        {
            try
            {
                int verifyId = 1; // 
                bool result = _verifyCompanyService.UpdateVerifyCompanyWithoutEF(id,verifyId);
                if (result)
                {
                    return Json(new { success = true, message = "Company has been denied!" });
                }
                throw new Exception();
            }
            catch
            {
                throw;
            }
        }

       
    }
}
