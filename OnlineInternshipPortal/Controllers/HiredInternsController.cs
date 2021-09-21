using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Controllers
{
    public class HiredInternsController : Controller
    {
        private readonly HiredInternService _hiredInternService;
        private readonly UserManager<ApplicationUser> _userManager;
        public HiredInternsController(HiredInternService hiredInternService, UserManager<ApplicationUser> userManager)
        {
            _hiredInternService = hiredInternService;
            _userManager = userManager;
        }

        // GET: HiredInternsController
        [Authorize(Roles = "Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InternsHired()   
        {
            return View();
        }

        [HttpGet]
         public async Task<ActionResult> CompanyHiredInternList()  
         {
            var user = await _userManager.GetUserAsync(User);
            var model = _hiredInternService.GetHiredInternsByCompany(user);
            return Json(new { data = model });
         }

       
        
        [HttpGet]
         public ActionResult AllHiredInternList()   
         {          
            var model = _hiredInternService.GetHiredInterns();
            return Json(new { data = model });
         }

        
        // GET: HiredInternsController/Delete/5
        [HttpDelete]
        
        public ActionResult DeleteHiredInterns(int id) 
        {
            try
            {
                bool result = _hiredInternService.RemoveHiredIntern(id); 
                if (result)
                {
                    return Json(new { success = true, message = "Hired Intern successfully deleted!" });
                }
                throw new Exception();
            }
            catch (Exception)
            {

                return View();
            }
            
            
        }

       
        
    }
}
