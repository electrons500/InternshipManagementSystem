using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class SentEmailsController : BaseController
    {

        private readonly SentMailService _sentMailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OnlineInternshipContext _db;

        public SentEmailsController(SentMailService sentMailService, UserManager<ApplicationUser> userManager, OnlineInternshipContext db)
        {
            _sentMailService = sentMailService;
            _userManager = userManager;
            _db = db;
        }

        // GET: SentEmailsController
        [Authorize(Roles = "Employer")] 
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> SentCompanyMailList() 
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _sentMailService.GetSentMailsOfCompany(user);
            return Json(new { data = model });

        }



        // GET: SentEmailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SentEmailsController/Create
        [Authorize(Roles = "Employer")]
        public ActionResult SendEmailToHiredIntern(int id)
        {
            var model = _sentMailService.GetHiredInternsDetails(id);
            
            return View(model);
        }

        // POST: SentEmailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmailToHiredIntern(SentMailsViewModel model,string id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                bool result = _sentMailService.SentMailToHiredInterns(model,user);
                if (result)
                {
                    Alert("Congratulations", "Message successfully sent!", NotificationType.success);
                   
                }
                return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult ViewSentEmailDetails(string id)  
        {
            
            var model = _sentMailService.GetSentMails(id);
            return View(model);
        }


        // DELETE: SentEmailsController/Delete/5
        [HttpDelete]
        public ActionResult RemoveEmailMessgeIndividually(string id) 
        {
            try
            {
                bool result = _sentMailService.DeleteMailBaseOnCompanyIdAndInternId(id);
                if (result)
                {
                    return Json(new { success = true, message = "Message successfully deleted!" });
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        //download attachment
        public IActionResult DownloadFileFromFileSystem(string id)
        {

            var file = _db.SentMsgToHiredInterns.Where(x => x.SentId == id).FirstOrDefault();
                                                                             
                                                                             
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Attachments + file.Extension);
        }

    }
}
