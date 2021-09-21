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
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{

    public class AccountController : BaseController
    {
        private readonly AccountRegistrationService _accountRegistrationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private OnlineInternshipContext _db;
        public AccountController(AccountRegistrationService accountRegistrationService, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, OnlineInternshipContext db
            )
        {
            _accountRegistrationService = accountRegistrationService;
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;

        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult StudentRegister()
        {

            var model = _accountRegistrationService.CreateSelectList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentRegister(AccountRegisterViewModel model)
        {
            

            try
            {
                bool validateDOB = ValidateDateOfBirth((DateTime)model.BirthDate);
                if (validateDOB)
                {
                    int id = 1;
                    //register users and assign student role to them
                    var result = await _accountRegistrationService.RegisterUserAsync(model, id);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        ViewData["Error"] = "result is false";
                    }
                }
                else
                {
                    Alert("Soory", "Please check your date of birth", NotificationType.error);
                }

               


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error exception occured", ex.Message);

            }

            var refreshDropdownlist = _accountRegistrationService.CreateSelectList();
            return View(refreshDropdownlist);
        }
        public IActionResult EmployerRegister()
        {

            var model = _accountRegistrationService.CreateSelectList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EmployerRegister(AccountRegisterViewModel model)
        {
            try
            {
                bool validateDOB = ValidateDateOfBirth((DateTime)model.BirthDate);
                if (validateDOB)
                {
                    int id = 2;
                    //register users and assign employee role to them
                    var result = await _accountRegistrationService.RegisterUserAsync(model, id);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        ViewData["Error"] = "result is false";
                    }

                }
                else
                {
                    Alert("Soory", "Please check your date of birth", NotificationType.error);
                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error exception occured", ex.Message);

            }

            var refreshDropdownlist = _accountRegistrationService.CreateSelectList();
            return View(refreshDropdownlist);
        }
        public IActionResult Login(int id)
        {
            ViewData["Id"] = id.ToString();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    var result = await _accountRegistrationService.UserLoginAsync(model);
                    if (result.Succeeded)
                    {
                        

                        MailAddress address = new(model.EmailAdress);
                        var userName = address.User;
                        var GetUserId = await _userManager.FindByNameAsync(userName);
                      
                        var UserHasRole = WhatRoleIsUser(GetUserId.Id); 

                        if (UserHasRole == "Student")
                        {
                            //go to student page
                            return RedirectToAction("Students", "Dashboard");
                        }
                        else if (UserHasRole == "Employer")
                        {
                            //go to employer page
                            return RedirectToAction("Employers", "Dashboard");
                        }
                        else
                        {
                            //go to admin page
                            return RedirectToAction("Admins", "Dashboard");
                        }
                    }
                    else
                    {
                        ViewData["Error"] = "Wrong email address or password";
                    }

                }
                else
                {
                    ViewData["Error"] = "Wrong email address or password";
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error exception occured", ex.Message);
                return View();
            }
        }
        //Get logged in user's role
        public string WhatRoleIsUser(string userId)
        {
            var GetUserRoleId = _db.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            var GetUserRole = _db.Roles.Where(x => x.Id == GetUserRoleId.RoleId).FirstOrDefault();


            return GetUserRole.Name;

        }


        public async Task<IActionResult> Logout()
        {
            await _accountRegistrationService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Student,Employer")]
        public async Task<IActionResult> GetUserDetails()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound("Sorry your account information doesnot exist!");
            var model = _accountRegistrationService.LoadUserAccountDetailsAsync(user);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> GetUserDetails(AccountRegisterViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                model.ProfilePic = user.ProfilePic;
                bool result = _accountRegistrationService.UpdateUserAccountAsync(model);
                if (result)
                {
                    var UserHasRole = WhatRoleIsUser(user.Id);
                    if(UserHasRole == "Student")
                    {
                        ViewData["UserRole"] = UserHasRole;
                    }
                    else
                    {
                        ViewData["UserRole"] = UserHasRole; //user role is Employer
                    }


                    Alert("Congratulations", "Your account has been successfully updated", NotificationType.success);
                }
                else
                {
                   
                    Alert("Soory", "Your account failed to updated", NotificationType.error);
                }

                var refreshdata = _accountRegistrationService.LoadUserAccountDetailsAsync(user);
                return View(refreshdata);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error exception occured", ex.Message);
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminDetails() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound("Sorry your account information doesnot exist!");
            var model = _accountRegistrationService.LoadUserAccountDetailsAsync(user); 

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> GetAdminDetails(AccountRegisterViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                model.ProfilePic = user.ProfilePic;
                bool result = _accountRegistrationService.UpdateUserAccountAsync(model);
                if (result)
                {
                   
                    
                    Alert("Congratulations", "Your account has been successfully updated", NotificationType.success);
                }
                else
                {
                    Alert("Soory", "Your account failed to updated", NotificationType.error);
                }

                var refreshdata = _accountRegistrationService.LoadUserAccountDetailsAsync(user);
                return View(refreshdata);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error exception occured", ex.Message);
                return View();
            }
        }

        //Admin
     
        public IActionResult Admin()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Admin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRegistrationService.UserLoginAsync(model);
                if (result.Succeeded)
                {
                    var GetUserId = await _userManager.FindByEmailAsync(model.EmailAdress);

                    var UserHasRole = WhatRoleIsUser(GetUserId.Id);

                    if (UserHasRole == "Admin")
                    {
                        //go to admin page
                        return RedirectToAction("Admins", "Dashboard");
                    }
                    else
                    {
                        
                        return RedirectToAction("Logout");
                    }
                }
                else
                {
                    ViewData["Error"] = "Wrong email address or password";
                }

            }
            else
            {
                ViewData["Error"] = "Invalid Email address";
            }

            return View();


        }

        public IActionResult AdminRegister()
        {
            var model = _accountRegistrationService.CreateSelectList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminRegister(AccountRegisterViewModel model)
        {
            bool validateDOB = ValidateDateOfBirth((DateTime)model.BirthDate); // check dob validity
            if (validateDOB) // if true then check email validity
            {
                int id = 3;

                bool EmailIsValid = _accountRegistrationService.IsValidEmail(model.EmailAdress);
                if (EmailIsValid)
                {
                    //register users and assign Admin role to them
                    var result = await _accountRegistrationService.RegisterUserAsync(model, id);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        ViewData["Error"] = "result is false";
                    }
                }
                else
                {
                    ViewData["Error"] = "result is false";
                }

            }
            else
            {
                Alert("Soory", "Please check your date of birth", NotificationType.error);
            }


            var refreshDropdownlist = _accountRegistrationService.CreateSelectList();
            return View(refreshDropdownlist);

        }


        public bool ValidateDateOfBirth(DateTime birthDate)
        {
            int DOByear = birthDate.Year;
            int currentyear = DateTime.Now.Year;
            int NumberOfYears = currentyear - DOByear;
            if(NumberOfYears >= 15) //the user must be 15 and above in order to register
            {
                return true;
            }

            return false;
        }



    }
}
