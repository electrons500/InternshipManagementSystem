using Microsoft.AspNetCore.Identity;
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
    public class SentMailService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SentMailService(OnlineInternshipContext.OnlineInternshipContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

       //List of Mails sent by a particular company
       public List<SentMailsViewModel> GetSentMailsOfCompany(ApplicationUser user)
        {
            var company = _db.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            List<SentMsgToHiredIntern> sentMsgs = _db.SentMsgToHiredInterns.Where(x => x.CompanyId == company.CompanyId)
                                                                           .Include(x => x.Company)
                                                                           .Include(x => x.Intern)
                                                                           .ToList();
            List<SentMailsViewModel> model = sentMsgs.Select(x => new SentMailsViewModel
            {
                SentId = x.SentId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                Subject = x.Subject,
                Messagebody = x.Messagebody,
                Attachments = x.Attachments,
                FilePath = x.FilePath,
                FileType = x.FileType,
                Extension = x.Extension,
                InternId = x.InternId,
                InternEmail = x.Intern.Email,
                InternName = x.Intern.FullName,
                SentDate = x.SentDate,
                SentTime = x.SentTime
            }).ToList();

            return model;
        }


        //List of all sent mails view by admin
        public List<SentMailsViewModel> GetAllSentMails()
        {
           
            List<SentMsgToHiredIntern> sentMsgs = _db.SentMsgToHiredInterns.Include(x => x.Company)
                                                                           .Include(x => x.Intern)
                                                                           .ToList();

            List<SentMailsViewModel> model = sentMsgs.Select(x => new SentMailsViewModel
            {
                SentId = x.SentId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                Subject = x.Subject,
                Messagebody = x.Messagebody,
                Attachments = x.Attachments,
                FilePath = x.FilePath,
                FileType = x.FileType,
                Extension = x.Extension,
                InternId = x.InternId,
                InternEmail = x.Intern.Email,
                InternName = x.Intern.FullName,
                SentDate = x.SentDate,
                SentTime = x.SentTime
            }).ToList();

            return model;
        }

      

        //company sents mails to hired applicants/interns
        public bool SentMailToHiredInterns(SentMailsViewModel model,ApplicationUser user)
        {
            string EmailAttachmentFileName = null;
            var company = _db.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            string day = DateTime.Now.Day.ToString();
            string Month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string Minutes = DateTime.Now.Minute.ToString();
            string Seconds = DateTime.Now.Second.ToString();
            string AddToFileName = $"{year}{Month}{day}{hour}{Minutes}{Seconds}";
            //if values in Sentstatus table exist 
            if (SentStatusValues() > 0 && ReceivedStatusValues() > 0 && ReadStatusValues() > 0)
            {
               
                if (model.AttachmentsIformfile != null)
                {

                    EmailAttachmentFileName = AddToFileName + "_" + model.AttachmentsIformfile.FileName;
                }
                else
                {
                    return false;
                }

                var FileDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Company\Attachments\"+ company.CompanyId);
             
                bool FilePathExists = Directory.Exists(FileDirectory);  
                if (!FilePathExists) Directory.CreateDirectory(FileDirectory);
                var fileName = Path.GetFileNameWithoutExtension(model.AttachmentsIformfile.FileName);
                var filePath = Path.Combine(FileDirectory, EmailAttachmentFileName);
                var extension = Path.GetExtension(EmailAttachmentFileName);
                string MailGuid = Guid.NewGuid().ToString();

                if (!File.Exists(filePath))
                {

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.AttachmentsIformfile.CopyTo(fileStream);
                    }

                    SentMsgToHiredIntern sentMsgToHiredIntern = new()
                    {
                        SentId = MailGuid,
                        CompanyId = company.CompanyId,
                        Subject = model.Subject,
                        Messagebody = model.Messagebody,
                        Attachments = fileName,
                        FileType = model.AttachmentsIformfile.ContentType,
                        Extension = extension,
                        FilePath = filePath,
                        InternId = model.InternId,
                        SentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                        SentTime = DateTime.Now.ToShortTimeString(),
                        SentStatusId = 1

                    };
                    _db.SentMsgToHiredInterns.Add(sentMsgToHiredIntern);
                    _db.SaveChanges();

                    //transfer sent content to receive
                    RecievedMsgFromCompany recievedMsgFromCompany = new()
                    {
                        RecieveId = MailGuid,
                        CompanyId = company.CompanyId,
                        Subject = model.Subject,
                        Messagebody = model.Messagebody,
                        Attachments = fileName,
                        FileType = model.AttachmentsIformfile.ContentType,
                        Extension = extension,
                        FilePath = filePath,
                        InternId = model.InternId,
                        ReceivedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                        ReceivedTime = DateTime.Now.ToShortTimeString(),
                        ReceivedStatusId = 2,
                        MsgReadStatusId = 1

                    };
                    _db.RecievedMsgFromCompanies.Add(recievedMsgFromCompany);
                    _db.SaveChanges();



                    return true;

                }
                            
               

            }

            return true;

        }

        //Add values to sent status table
        public int SentStatusValues()
        {
            int countstatus = _db.SentStatuses.Count();
            if(countstatus == 0)
            {
                int NumberOfValues;
                SentStatus statusOne = new()
                {
                    StatusName = "Pending"
                };
                _db.SentStatuses.Add(statusOne);
                _db.SaveChanges();
                SentStatus statusTwo = new()
                {
                    StatusName = "Sent"
                };
                _db.SentStatuses.Add(statusTwo);
                _db.SaveChanges();
                SentStatus statusThree = new()
                {
                    StatusName = "Not Sent"
                };
                _db.SentStatuses.Add(statusThree);
                _db.SaveChanges();
                NumberOfValues = 3;

                return NumberOfValues;
            }
            else
            {
                return countstatus;
            }
            
           

        }

        public int ReadStatusValues()
        {
            int countstatus = _db.MsgReadStatuses.Count();

            if (countstatus == 0)
            {
                int NumberOfValues;
                MsgReadStatus statusOne = new()
                {
                    MsgReadStatusName = "No"
                };
                _db.MsgReadStatuses.Add(statusOne);
                _db.SaveChanges();
                MsgReadStatus statusTwo = new()
                {
                    MsgReadStatusName = "Yes"
                };
                _db.MsgReadStatuses.Add(statusTwo);
                _db.SaveChanges();

                NumberOfValues = 2;

                return NumberOfValues;
            }
            else
            {
                return countstatus;
            }



        }
        public int ReceivedStatusValues()
        {

            int countMsgReceived = _db.RecievedStatuses.Count();
            if (countMsgReceived == 0)
            {
                int NumberOfValues;
               RecievedStatus statusOne = new()
                {
                   ReceiveStatusName= "Pending"
                };
                _db.RecievedStatuses.Add(statusOne);
                _db.SaveChanges();
                RecievedStatus statusTwo = new()
                {
                    ReceiveStatusName = "Received"
                };
                _db.RecievedStatuses.Add(statusTwo);
                _db.SaveChanges();

                NumberOfValues = 2;

                return NumberOfValues;
            }
            else
            {
                return countMsgReceived;
            }



        }



        //Delete mails
        public bool DeleteMailBaseOnCompanyIdAndInternId(string id)
        {
            var senderMails = _db.SentMsgToHiredInterns.Where(x => x.SentId == id).FirstOrDefault();
            bool result = CheckIfMailAndAttachmentExist(id);
            if (result)
            {
                File.Delete(senderMails.FilePath);
                _db.SentMsgToHiredInterns.Remove(senderMails);
                _db.SaveChanges();
                return true;
            }
            else { return false; }

           

        }

        //Before we delete check if mail and attachment exist
        private bool CheckIfMailAndAttachmentExist(string id)
        {
            var senderMails = _db.SentMsgToHiredInterns.Where(x => x.SentId == id).FirstOrDefault();
            var filePath = senderMails.FilePath;
            bool fileExist = File.Exists(filePath);
            if(senderMails.Attachments != null && fileExist ==true )
            {
                return true;
                
             }
            else
            {
                return false;
            }
            
        }

        //company Deletes all it sent Mails in bulk
        public bool DeleteAllMailsByCompany(ApplicationUser user)
        {
            var company = _db.Companies.Where(x => x.UserId == user.Id).FirstOrDefault();
            List<SentMsgToHiredIntern> sentMsgs = _db.SentMsgToHiredInterns.Where(x => x.CompanyId == company.CompanyId)
                                                                           .Include(x => x.Company)
                                                                           .Include(x => x.Intern)
                                                                           .ToList();
            _db.SentMsgToHiredInterns.RemoveRange(sentMsgs);
            _db.SaveChanges();

            return true;

        }

        //Admin deleting all sent mails
        public bool DeleteAllMailsByAdmin()
        {
            
            List<SentMsgToHiredIntern> sentMsgs = _db.SentMsgToHiredInterns.Include(x => x.Company)
                                                                           .Include(x => x.Intern)
                                                                           .ToList();

            _db.SentMsgToHiredInterns.RemoveRange(sentMsgs);
            _db.SaveChanges();

            return true;

        }

        public List<SentMailsViewModel> SentMailsList { get; set; }
        //Get HiredIntern table details of an applicant and populate to SendEmailToHiredIntern view
        public SentMailsViewModel GetHiredInternsDetails(int id)
        {
            var hiredInterns = _db.Hireds.Where(x => x.HireId == id).Include(x => x.Company).Include(x => x.Intern).FirstOrDefault();
            SentMailsViewModel model = new()
            {
                CompanyId = hiredInterns.CompanyId,
                CompanyName = hiredInterns.Company.CompanyName,
                CompanyEmail = hiredInterns.Company.CompanyEmail,
                InternId = hiredInterns.InternId,
                InternEmail = hiredInterns.Intern.Email,
                InternName = hiredInterns.Intern.FullName

            };

            return model;
        }

        //Email details
        public SentMailsViewModel GetSentMails(string id)
        {
            var sentMsg = _db.SentMsgToHiredInterns.Where(x => x.SentId == id).Include(x => x.Company)
                                                                               .Include(x => x.Intern)
                                                                               .Include(x => x.SentStatus)
                                                                               .FirstOrDefault();

            SentMailsViewModel model = new()
            {
                SentId = sentMsg.SentId,
                CompanyId = sentMsg.CompanyId,
                CompanyEmail = sentMsg.Company.CompanyEmail,
                Subject = sentMsg.Subject,
                Messagebody = sentMsg.Messagebody,
                Attachments = sentMsg.Attachments,
                FilePath = sentMsg.FilePath,
                Extension = sentMsg.Extension,
                SentDate = sentMsg.SentDate,
                SentTime = sentMsg.SentTime,
                SentStatusId = sentMsg.SentStatusId,
                SentStatusName = sentMsg.SentStatus.StatusName,
                InternId = sentMsg.InternId,
                InternEmail = sentMsg.Intern.Email,
                InternName = sentMsg.Intern.FirstName

            };

            return model;

        }
        

    }
}
