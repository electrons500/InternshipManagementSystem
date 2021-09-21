using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInternshipPortal.Models.Data.Services;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admins()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AdminsList()
        {
            List<UserRoleViewModel> users = new();
            users = _usersService.GetAdmins();
            return Json(new { data = users });

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Employers()
        {

            return View();
        }
        [HttpGet]
        public IActionResult EmployersList()
        {
            List<UserRoleViewModel> users = new();
            users = _usersService.GetEmployers();
            return Json(new { data = users });

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Students()
        {

            return View();
        }
        [HttpGet]
        public IActionResult StudentList()
        {
            List<UserRoleViewModel> users = new();
            users = _usersService.GetStudent();
            return Json(new { data = users });
        }


        [Authorize(Roles = "Admin")]
        //User details
        public IActionResult GetUserDetails(string id)
        {
            var model = _usersService.GetUserDetails(id);
            return View(model);
        }



    }
}
