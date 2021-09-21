using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class InternService
    {
        private readonly OnlineInternshipContext.OnlineInternshipContext _db;

        public InternService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
        }

        //create interns
        public InternsViewModel CreateInterns(ApplicationUser user)
        {
            InternsViewModel model = new()
            {
                RegionList = new SelectList(_db.Regions, "RegionId", "RegionName"),
                GenderList = new SelectList(_db.Genders, "GenderId", "GenderName"),
                SchoolList = new SelectList(_db.Schools, "SchoolId", "SchoolName"),
                GuardianCategoryList = new SelectList(_db.GuardianCategories, "GuardianCategoryId", "Name"),

                //user details that was given during creating a new user account
                LastName = user.LastName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                BirthDate = user.BirthDate,
                Email = user.Email


            };

            return model;

        }

        //List interns
        public List<InternsViewModel> GetInterns()
        {
            List<Intern> interns = _db.Interns.Include(x => x.Gender)
                                              .Include(x => x.School)
                                              .Include(x => x.Region)
                                              .Include(x => x.Cv)
                                              .Include(x => x.Guardian.GuardianCategory)
                                              .ToList();
            List<InternsViewModel> model = interns.Select(x => new InternsViewModel
            {
                InternId = x.InternId,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                FirstName = x.FirstName,
                FullName = $"{x.FirstName} {x.MiddleName} {x.LastName}",
                BirthDate = x.BirthDate,
                HomeTown = x.HomeTown,
                Address = x.Address,
                Email = x.Email,
                ContactNumber = x.ContactNumber,
                GenderId = x.GenderId,
                GenderName = x.Gender.GenderName,
                RegionId = x.RegionId,
                RegionName = x.Region.RegionName,
               Residence = x.Residence,
               GuardianId = x.GuardianId,
               GuardianName = x.Guardian.GuardianName,
               GuardianCategoryId = x.Guardian.GuardianCategoryId,
               GuardianContactNumber = x.Guardian.ContactNumber,
               GuardianResidence = x.Guardian.Residence,
               SchoolId = x.SchoolId,
               SchoolName = x.School.SchoolName,
               StudentIdCardNumber = x.StudentIdCardNumber,
               Photo = x.Photo,
               CvId = x.CvId,
               CVfilename = x.Cv.Filename,
               Course = x.Course,
               RegistrationDate = x.RegistrationDate
               

            }).ToList();


            return model;

        }

        //Details
        public InternsViewModel GetInternsDetails(string id)
        {

            try
            {
                Intern interns = _db.Interns.Where(x => x.InternId == id).Include(x => x.Gender)
                                                     .Include(x => x.School)
                                                     .Include(x => x.Region)
                                                     .Include(x => x.Cv)
                                                     .Include(x => x.Guardian)
                                                     .Include(x => x.Guardian.GuardianCategory)
                                                     .FirstOrDefault();
                InternsViewModel model = new()
                {
                    InternId = interns.InternId,
                    LastName = interns.LastName,
                    MiddleName = interns.MiddleName,
                    FirstName = interns.FirstName,
                    FullName = $"{interns.FirstName} {interns.MiddleName} {interns.LastName}",
                    BirthDate = interns.BirthDate,
                    HomeTown = interns.HomeTown,
                    Address = interns.Address,
                    Email = interns.Email,
                    ContactNumber = interns.ContactNumber,
                    GenderId = interns.GenderId,
                    GenderName = interns.Gender.GenderName,
                    RegionId = interns.RegionId,
                    RegionName = interns.Region.RegionName,
                    Residence = interns.Residence,
                    GuardianId = interns.GuardianId,
                    GuardianName = interns.Guardian.GuardianName,
                    GuardianCategoryId = interns.Guardian.GuardianCategoryId,
                    GuardianContactNumber = interns.Guardian.ContactNumber,
                    GuardianResidence = interns.Guardian.Residence,
                    GuardianCategoryName = interns.Guardian.GuardianCategory.Name,
                    SchoolId = interns.SchoolId,
                    SchoolName = interns.School.SchoolName,
                    StudentIdCardNumber = interns.StudentIdCardNumber,
                    Photo = interns.Photo,
                    CvId = interns.CvId,
                    CVfilename = interns.Cv.Filename,
                    Course = interns.Course,
                    RegionList = new SelectList(_db.Regions, "RegionId", "RegionName"),
                    GenderList = new SelectList(_db.Genders, "GenderId", "GenderName"),
                    SchoolList = new SelectList(_db.Schools, "SchoolId", "SchoolName"),
                    GuardianCategoryList = new SelectList(_db.GuardianCategories, "GuardianCategoryId", "Name"),
                    RegistrationDate = interns.RegistrationDate


                };

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
         public InternsViewModel GetStudentDetails(ApplicationUser user)   
        {

            try
            {
                Intern interns = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).Include(x => x.Gender)
                                                     .Include(x => x.School)
                                                     .Include(x => x.Region)
                                                     .Include(x => x.Cv)
                                                     .Include(x => x.Guardian)
                                                     .Include(x => x.Guardian.GuardianCategory)
                                                     .FirstOrDefault();
                InternsViewModel model = new()
                {
                    InternId = interns.InternId,
                    LastName = interns.LastName,
                    MiddleName = interns.MiddleName,
                    FirstName = interns.FirstName,
                    FullName = $"{interns.FirstName} {interns.MiddleName} {interns.LastName}",
                    BirthDate = interns.BirthDate,
                    HomeTown = interns.HomeTown,
                    Address = interns.Address,
                    Email = interns.Email,
                    ContactNumber = interns.ContactNumber,
                    GenderId = interns.GenderId,
                    GenderName = interns.Gender.GenderName,
                    RegionId = interns.RegionId,
                    RegionName = interns.Region.RegionName,
                    Residence = interns.Residence,
                    GuardianId = interns.GuardianId,
                    GuardianName = interns.Guardian.GuardianName,
                    GuardianCategoryId = interns.Guardian.GuardianCategoryId,
                    GuardianContactNumber = interns.Guardian.ContactNumber,
                    GuardianResidence = interns.Guardian.Residence,
                    GuardianCategoryName = interns.Guardian.GuardianCategory.Name,
                    SchoolId = interns.SchoolId,
                    SchoolName = interns.School.SchoolName,
                    StudentIdCardNumber = interns.StudentIdCardNumber,
                    Photo = interns.Photo,
                    CvId = interns.CvId,
                    CVfilename = interns.Cv.Filename,
                    Course = interns.Course,
                    RegionList = new SelectList(_db.Regions, "RegionId", "RegionName"),
                    GenderList = new SelectList(_db.Genders, "GenderId", "GenderName"),
                    SchoolList = new SelectList(_db.Schools, "SchoolId", "SchoolName"),
                    GuardianCategoryList = new SelectList(_db.GuardianCategories, "GuardianCategoryId", "Name"),
                    RegistrationDate = interns.RegistrationDate

                };

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Add interns
        public bool AddInterns(InternsViewModel model)
        {
            string StudentImageName = UploadStudentPhotoFile(model);
            string StudentCV_Filename = UploadStudentCVFile(model);
            int guardianId, cvId;
            
            Guardian guardian = new();
           
            Cv cv = new();
            //guardian
            guardian = new()
            {
                GuardianName = model.GuardianName,
                GuardianCategoryId = model.GuardianCategoryId,
                ContactNumber = model.GuardianContactNumber,
                Residence = model.GuardianResidence

            };
            _db.Guardians.Add(guardian);
            _db.SaveChanges();
            guardianId = guardian.GuardianId;

            //Cv         
                cv = new Cv()
                {
                    Filename = StudentCV_Filename
                };
                _db.Cvs.Add(cv);
                _db.SaveChanges();
                cvId = cv.CvId;


            Intern interns = new()
            {
                InternId = Guid.NewGuid().ToString(),

                LastName = model.LastName,
                MiddleName = model.MiddleName,
                FirstName = model.FirstName,
                FullName = $"{model.FirstName} {model.MiddleName} {model.LastName}",
                BirthDate = model.BirthDate,
                HomeTown = model.HomeTown,
                Address = model.Address,
                Email = model.Email,
                ContactNumber = model.ContactNumber,
                GenderId = model.GenderId,

                RegionId = model.RegionId,

                Residence = model.Residence,
                GuardianId = guardianId,

                SchoolId = model.SchoolId,

                StudentIdCardNumber = model.StudentIdCardNumber,
                Photo = StudentImageName,
                CvId = cvId,

                Course = model.Course,
                RegistrationDate = DateTime.Now


            };

            _db.Interns.Add(interns);
            _db.SaveChanges();


            return true;


        }

        private string UploadStudentPhotoFile(InternsViewModel model)
        {

            // save pictures into a folder
            string NewFileName = null;

            if (model.StudentImage != null)
            {

                NewFileName = Guid.NewGuid().ToString() + "_" + model.StudentImage.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Students\StudentImages", NewFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.StudentImage.CopyTo(fileStream);
                }
            }
            return NewFileName;
        }

        private string UploadStudentCVFile(InternsViewModel model)
        {

            // save pictures into a folder
            string NewCvFilename = null;

            if (model.CVfile != null)
            {

                NewCvFilename = Guid.NewGuid().ToString() + "_" + model.CVfile.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Students\CVs", NewCvFilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CVfile.CopyTo(fileStream);
                }
            }
            return NewCvFilename;
        }


        public bool UpdateInterns(InternsViewModel model)
        {
           
            string StudentCV_Filename = null;
            string StudentImageName = null;
            int guardianId = 0;
            int cvId = 0;


            Intern interns = _db.Interns.Where(x => x.InternId == model.InternId).Include(x => x.Gender)
                                            .Include(x => x.School)
                                            .Include(x => x.Region)
                                            .Include(x => x.Cv)
                                            .FirstOrDefault();
            model.CvId = interns.CvId;
            model.FullName = interns.FullName;
            model.Photo = interns.Photo;

            var PhotofilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Students\StudentImages", model.Photo);
           

           
            Cv cv = _db.Cvs.Where(x => x.CvId == interns.CvId).FirstOrDefault();

            var CVfilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Students\CVs",cv.Filename);

            //update photo
            if (interns.Photo != null && model.StudentImage != null)
            {
                if (File.Exists(PhotofilePath))
                {
                    File.Delete(PhotofilePath);
                }
                 StudentImageName = UploadStudentPhotoFile(model);
            }
            else
            {
                StudentImageName = interns.Photo;
            }

            //cv
            if(interns.CvId != 0 && model.CVfile != null)
            {
                if (File.Exists(CVfilePath))
                {
                    File.Delete(CVfilePath);
                }
                StudentCV_Filename = UploadStudentCVFile(model);
                cv.Filename = StudentCV_Filename;
                _db.Cvs.Update(cv);
                _db.SaveChanges();
                cvId = cv.CvId;
            }
            else
            {
                cvId = interns.CvId;
            }

            //Guardian
            if(interns.GuardianId != 0)
            {
                Guardian guardian = _db.Guardians.Where(x => x.GuardianId == interns.GuardianId).FirstOrDefault();
                guardian.GuardianName = model.GuardianName;
                guardian.GuardianCategoryId = model.GuardianCategoryId;
                guardian.ContactNumber = model.GuardianContactNumber;
                guardian.Residence = model.GuardianResidence;
                _db.Guardians.Update(guardian);
                _db.SaveChanges();
                guardianId = guardian.GuardianId;

            }


            interns.LastName = model.LastName;
            interns.MiddleName = model.MiddleName;
            interns.FirstName = model.FirstName;
            interns.FullName = $"{model.FirstName} {model.MiddleName} {model.LastName}";
            interns.BirthDate = model.BirthDate;
            interns.HomeTown = model.HomeTown;
            interns.Address = model.Address;
            interns.Email = model.Email;
            interns.ContactNumber = model.ContactNumber;
            interns.GenderId = model.GenderId;

            interns.RegionId = model.RegionId;

            interns.Residence = model.Residence;
            interns.GuardianId = guardianId;

            interns.SchoolId = model.SchoolId;

            interns.StudentIdCardNumber = model.StudentIdCardNumber;
            interns.Photo = StudentImageName;
            interns.CvId = cvId;

            interns.Course = model.Course;

            _db.Interns.Update(interns);
            _db.SaveChanges();

            return true;

        }


    }
}
