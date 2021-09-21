using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class ReceivedMsgFromCompanyService
    {
        private OnlineInternshipContext.OnlineInternshipContext _db;
        
        public ReceivedMsgFromCompanyService(OnlineInternshipContext.OnlineInternshipContext db)
        {
            _db = db;
            
        }

        //Student can see only their received mails
        public List<ReceivedMsgFromCompanyViewModel> GetReceivedMsgFromCompanies(ApplicationUser user)
        {
            Intern intern = _db.Interns.Where(x => x.Email == user.Email && x.FirstName == user.FirstName).FirstOrDefault();
            List<RecievedMsgFromCompany> recievedMsgs = _db.RecievedMsgFromCompanies.Where(x => x.InternId == intern.InternId)
                                                                                    .Include(x => x.Company)
                                                                                    .Include(x => x.Intern)
                                                                                    .Include(x => x.ReceivedStatus)
                                                                                    .Include(x => x.MsgReadStatus)
                                                                                    .ToList();


            List<ReceivedMsgFromCompanyViewModel> model = recievedMsgs.Select(x => new ReceivedMsgFromCompanyViewModel
            {
                RecieveId = x.RecieveId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
                CompanyEmail = x.Company.CompanyEmail,
                Subject = x.Subject,
                Messagebody = x.Messagebody,
                Attachments = x.Attachments,
                FilePath = x.FilePath,
                FileType = x.FileType,
                Extension = x.Extension,
                InternId = x.InternId,
                InternEmail = x.Intern.Email,
                InternName = x.Intern.FullName,
                ReceivedDate = x.ReceivedDate,
                ReceivedTime = x.ReceivedTime,
                ReceivedStatusId = x.ReceivedStatusId,
                ReceiveStatusName = x.ReceivedStatus.ReceiveStatusName,
                MsgReadStatusId = x.MsgReadStatusId,
                MsgReadStatusName = x.MsgReadStatus.MsgReadStatusName
            }).ToList();

            return model;

        }

        //Admin seeing all student received mails
        public List<ReceivedMsgFromCompanyViewModel> GetAllStudentReceivedMail()
        {
          
            List<RecievedMsgFromCompany> recievedMsgs = _db.RecievedMsgFromCompanies.Include(x => x.Company)
                                                                                    .Include(x => x.Intern)
                                                                                    .Include(x => x.ReceivedStatus)
                                                                                    .Include(x => x.MsgReadStatus)
                                                                                    .ToList();



            List<ReceivedMsgFromCompanyViewModel> model = recievedMsgs.Select(x => new ReceivedMsgFromCompanyViewModel
            {
                RecieveId = x.RecieveId,
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
                ReceivedDate = x.ReceivedDate,
                ReceivedTime = x.ReceivedTime,
                ReceivedStatusId = x.ReceivedStatusId,
                ReceiveStatusName = x.ReceivedStatus.ReceiveStatusName,
                MsgReadStatusId = x.MsgReadStatusId,
                MsgReadStatusName = x.MsgReadStatus.MsgReadStatusName
            }).ToList();

            return model;

        }


        //Mail details for both student and admin
        public ReceivedMsgFromCompanyViewModel GetReceivedMsgDetails(string receivedId)
        {
            RecievedMsgFromCompany receivedmsg = _db.RecievedMsgFromCompanies.Where(x => x.RecieveId == receivedId)
                                                                             .Include(x => x.Company)
                                                                             .Include(x => x.Intern)
                                                                             .Include(x => x.ReceivedStatus)
                                                                             .Include(x => x.MsgReadStatus)
                                                                             .FirstOrDefault();

            ReceivedMsgFromCompanyViewModel model = new()
            {
                RecieveId = receivedmsg.RecieveId,
                CompanyId = receivedmsg.CompanyId,
                CompanyName = receivedmsg.Company.CompanyName,
                Subject = receivedmsg.Subject,
                Messagebody = receivedmsg.Messagebody,
                Attachments = receivedmsg.Attachments,
                FilePath = receivedmsg.FilePath,
                FileType = receivedmsg.FileType,
                Extension = receivedmsg.Extension,
                InternId = receivedmsg.InternId,
                InternEmail = receivedmsg.Intern.Email,
                InternName = receivedmsg.Intern.FullName,
                ReceivedDate = receivedmsg.ReceivedDate,
                ReceivedTime = receivedmsg.ReceivedTime,
                ReceivedStatusId = receivedmsg.ReceivedStatusId,
                ReceiveStatusName = receivedmsg.ReceivedStatus.ReceiveStatusName,
                MsgReadStatusId = receivedmsg.MsgReadStatusId,
                MsgReadStatusName = receivedmsg.MsgReadStatus.MsgReadStatusName
            };

            return model;

        }


        //delete mail one by one
        public bool DeleteMails(string receivedId)
        {
            RecievedMsgFromCompany recievedMsg = _db.RecievedMsgFromCompanies.Where(x => x.RecieveId == receivedId).FirstOrDefault();
            _db.RecievedMsgFromCompanies.Remove(recievedMsg);
            int i = _db.SaveChanges();

           if(i > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }

        //delete all existing received mails for admin only
        public bool DeleteAllMails() 
        {
            List<RecievedMsgFromCompany> recievedMsgs = _db.RecievedMsgFromCompanies.ToList();
            _db.RecievedMsgFromCompanies.RemoveRange(recievedMsgs);
            int i = _db.SaveChanges();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
