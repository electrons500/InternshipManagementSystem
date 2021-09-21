using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineInternshipPortal.Models;
using OnlineInternshipPortal.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeService _homeService;
        private readonly AccountRegistrationService _accountRegistrationService;
        private readonly SectorService _Sectorservice;
        private readonly VerifiedCategoryService _verifiedCategoryService;
        private readonly InternshipStatusService _internshipStatusService;
        private readonly RemoteInternshipService _remoteInternshipService;
        private readonly PublicizedService _publicizedService;
        private readonly SentMailService _sentMailService;
        public HomeController(ILogger<HomeController> logger, HomeService homeService,
            AccountRegistrationService accountRegistrationService, SectorService sectorService,
            VerifiedCategoryService verifiedCategoryService, InternshipStatusService internshipStatusService,
            RemoteInternshipService remoteInternshipService, PublicizedService publicizedService, SentMailService sentMailService

            )
        {
            _logger = logger;
            _homeService = homeService;
            _accountRegistrationService = accountRegistrationService;
            _Sectorservice = sectorService;
            _verifiedCategoryService = verifiedCategoryService;
            _internshipStatusService = internshipStatusService;
            _remoteInternshipService = remoteInternshipService;
            _publicizedService = publicizedService;
            _sentMailService = sentMailService;
        }

        public async Task<IActionResult> Index()
        {
            //for user roles
            await _accountRegistrationService.GenerateRolesAsync();
            // create values for gender table
            _accountRegistrationService.InsertGenderValuesIntoDB();
            //create values for industry and designation table
            _homeService.InsertValues(); 
            //create values for region table
            _accountRegistrationService.InsertRegionValuesIntoDB();
            //values for verified category
            _verifiedCategoryService.AddVerifiedCategory();
             
            //for sector table
            _Sectorservice.CreateSectors();
            //Internship status
            _internshipStatusService.AddInternshipStatus();
            //RemoteInternship
            _remoteInternshipService.AddRemoteInternship();
            //for publicize
            _publicizedService.AddValueToPublicize();

            //for msgReadStatus
            int msgReadStatus = _sentMailService.ReadStatusValues();
            int SentStatusValues = _sentMailService.SentStatusValues();
            int ReceivedStatusValues = _sentMailService.ReceivedStatusValues();

            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
