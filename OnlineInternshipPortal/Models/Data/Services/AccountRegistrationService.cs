using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;

namespace OnlineInternshipPortal.Models.Data.Services
{

    public class AccountRegistrationService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ApplicationUser> _logger;

     

        public AccountRegistrationService(OnlineInternshipContext.OnlineInternshipContext db,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager, ILogger<ApplicationUser> logger 
            )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager; 
            _logger = logger;
        }

        public AccountRegisterViewModel CreateSelectList()
        {
            AccountRegisterViewModel model = new()
            {
                GenderList = new SelectList(_db.Genders, "GenderId", "GenderName"),
                RegionList = new SelectList(_db.Regions, "RegionId", "RegionName")
            };

            return model;


        }

        public void InsertGenderValuesIntoDB()
        {
            //Incase there is no value in Gender Table in DB then
            //create the values and store in the DB
            try
            {
                var genda = _db.Genders.Count();
                if (genda == 0)
                {
                    Gender femaleGender = new()
                    {
                        GenderName = "Male"
                    };
                    _db.Genders.Add(femaleGender);
                    _db.SaveChanges();
                    Gender maleGender = new()
                    {
                        GenderName = "Female"
                    };
                    _db.Genders.Add(maleGender);
                    _db.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRegionValuesIntoDB()
        {
            try
            {
                //Incase there is no value in Region Table in DB then
                //create the values and store in the DB
                var region = _db.Regions.Count();
                if (region == 0)
                {
                    List<Region> regions = new()
                    {

                        new Region() { RegionName = "Ahafo region" },
                        new Region() { RegionName = "Ashanti region" },
                        new Region() { RegionName = "Brong Ahafo region" },
                        new Region() { RegionName = "Bono region" },
                        new Region() { RegionName = "Central region" },
                        new Region() { RegionName = "Eastern region" },
                        new Region() { RegionName = "Greater Accra region" },
                        new Region() { RegionName = "Northern region" },
                        new Region() { RegionName = "North East region" },
                        new Region() { RegionName = "Oti Region" },
                        new Region() { RegionName = "Savannah region" },
                        new Region() { RegionName = "Upper East region" },
                        new Region() { RegionName = "Upper West region" },
                        new Region() { RegionName = "Volta region" },
                        new Region() { RegionName = "Western region" },
                        new Region() { RegionName = "Western North Region" }


                    };

                    foreach (var items in regions)
                    {
                        Region regionsInGhana = new()
                        {
                            RegionName = items.RegionName
                        };
                        _db.Regions.Add(regionsInGhana);
                        _db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Create user roles in they are not in the DB
        public async Task GenerateRolesAsync()
        {

            var AdminExist = await _roleManager.FindByNameAsync("Admin");
            var StudentExist = await _roleManager.FindByNameAsync("Student");
            var EmployeeExist = await _roleManager.FindByNameAsync("Employer");

            if (AdminExist == null)
            {
                var CreateAdmin = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            }
            if (StudentExist == null)
            {
                var CreateStudent = _roleManager.CreateAsync(new IdentityRole("Student")).Result;
            }
            if (EmployeeExist == null)
            {
                var CreateEmployee = _roleManager.CreateAsync(new IdentityRole("Employer")).Result;
            }


        }

        public async Task<IdentityResult> RegisterUserAsync(AccountRegisterViewModel model, int id)
        {
            MailAddress address = new(model.EmailAdress);
            var userName = address.User;

            var newUser = new ApplicationUser
            {
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                FirstName = model.FirstName,
                FullName = $"{model.FirstName} {model.MiddleName} {model.LastName}",
                BirthDate = model.BirthDate,
                GenderId = model.GenderId,
                HomeTown = model.HomeTown,
                RegionId = model.RegionId,
                Residence = model.Residence,
                Address = model.Address,              
                PhoneNumber = model.ContactNumber,             
                Email = model.EmailAdress,
                UserName = userName,
                RegistrationDate = DateTime.Now

            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
           
            if (result.Succeeded)
            {
                if (id == 1)
                {
                    await _userManager.AddToRoleAsync(newUser, "Student");
                }
                else if (id == 2)
                {
                    await _userManager.AddToRoleAsync(newUser, "Employer");
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }

            }
           
            return result;
        }

        public async Task<SignInResult> UserLoginAsync(LoginViewModel model)
        {
            var userName = model.EmailAdress;
            

            if (IsValidEmail(model.EmailAdress))
            {
                MailAddress mailAddress = new(model.EmailAdress);
                userName = mailAddress.User;
                         
               
            }
            bool RememberMe = true;
            var result = await _signInManager.PasswordSignInAsync(userName, model.Password, RememberMe, lockoutOnFailure: false);

            return result;

        }

        public bool IsValidEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match) 
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        string domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException )
                {
                    return false;
                }
                catch (ArgumentException )
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }





            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public AccountRegisterViewModel LoadUserAccountDetailsAsync(ApplicationUser user)
        {
            var Id = user.Id;
            var FirstName = user.FirstName; 
            var LastName = user.LastName;
            var MiddleName = user.MiddleName;
            var BirthDate = user.BirthDate;
            var GenderId = user.GenderId;
            var HomeTown = user.HomeTown;
            var RegionId = user.RegionId;
            var Residence = user.Residence;
            var Address = user.Address;
            var EmailAdress = user.Email;
            var ContactNumber = user.PhoneNumber;
            var ProfilePic = user.ProfilePic;


            AccountRegisterViewModel model = new()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                BirthDate = BirthDate,
                GenderId = GenderId,
                GenderList = new SelectList(_db.Genders,"GenderId","GenderName"),
                HomeTown = HomeTown,
                RegionId = RegionId,
                RegionList = new SelectList(_db.Regions, "RegionId","RegionName"),
                Residence = Residence,
                Address = Address,
                EmailAdress = EmailAdress,
                ContactNumber = ContactNumber,
                ProfilePic = ProfilePic


            };

            return model;
        }

       public bool  UpdateUserAccountAsync(AccountRegisterViewModel model)
        {
            byte[] ImageByte;

            if (model.UserImage != null && model.ProfilePic == null) //user inserted a picture for the firsttime 
            {

                using (var stream = new MemoryStream())
                {
                    model.UserImage.CopyTo(stream);
                    ImageByte = stream.ToArray();
                }

                model.ProfilePic = ImageByte;
            }else if (model.UserImage != null && model.ProfilePic != null) // user want to update profile picture
            {
                using (var stream = new MemoryStream())
                {
                    model.UserImage.CopyTo(stream);
                    ImageByte = stream.ToArray();
                }

                model.ProfilePic = ImageByte;
            }
            else
            {
                ImageByte = model.ProfilePic;
            }


            var user = _db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            user.FirstName = model.FirstName;
            user.MiddleName = model.MiddleName;
            user.LastName = model.LastName;
            user.FullName = $"{model.FirstName} {model.MiddleName} {model.LastName}";
            user.BirthDate = model.BirthDate;
            user.GenderId = model.GenderId;
            user.HomeTown = model.HomeTown;
            user.RegionId = model.RegionId;
            user.Residence = model.Residence;
            user.Address = model.Address;
            user.PhoneNumber = model.ContactNumber;
            user.ProfilePic = ImageByte;

            _db.Users.Update(user);
            _db.SaveChanges();

            return true;

        }

    }
}
