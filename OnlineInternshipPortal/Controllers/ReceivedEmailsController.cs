using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class ReceivedEmailsController : BaseController
    {
        private readonly ReceivedMsgFromCompanyService _receivedMsgFromCompanyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OnlineInternshipContext _db;
        public ReceivedEmailsController(ReceivedMsgFromCompanyService receivedMsgFromCompanyService, UserManager<ApplicationUser> userManager, OnlineInternshipContext db)
        {
            _receivedMsgFromCompanyService = receivedMsgFromCompanyService;
            _userManager = userManager;
            _db = db;
        }


        // GET: ReceivedEmailsController
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> Index() 
        {
            var user = await _userManager.GetUserAsync(User);
            int Countinterns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Count();

            if (Countinterns == 0)
            {
                Alert("Sorry", "Please add your student information first", NotificationType.error);
                return RedirectToAction("Students", "Dashboard");
            }
            else
            {
                return View();
            }

            
        }
        [HttpGet]
        public async Task<ActionResult> ReceivedMailList()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _receivedMsgFromCompanyService.GetReceivedMsgFromCompanies(user);
            return Json(new { data = model });

        }

        // GET: ReceivedEmailsController/Details/5
        public ActionResult ReceivedMailDetails(string id)
        {
            var model = _receivedMsgFromCompanyService.GetReceivedMsgDetails(id);
            return View(model);
        }

      
        [HttpDelete]
        public ActionResult DeleteMails(string id)
        {
            try
            {
                bool result = _receivedMsgFromCompanyService.DeleteMails(id);
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

        public IActionResult DownloadFileFromFileSystem(string id)
        {

            var file = _db.RecievedMsgFromCompanies.Where(x => x.RecieveId == id).FirstOrDefault();


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
