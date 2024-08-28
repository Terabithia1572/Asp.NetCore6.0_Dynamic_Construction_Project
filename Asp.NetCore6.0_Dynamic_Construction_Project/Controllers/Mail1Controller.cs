using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using DNTCaptcha.Core;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    public class Mail1Controller : Controller
    {
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;
        MailManager mailManager=new MailManager(new EfMailRepository());
        public IActionResult Index()
        {
            var values = mailManager.GetList();
            return View(values);
        }
        public IActionResult MailDetail(int id)
        {
            var values=mailManager.GetMailByID(id);
            return View(values);
        }
        public IActionResult DeleteMail(int id)
        {
            var values = mailManager.TGetByID(id);

            mailManager.TDelete(values);

            return RedirectToAction("Index", "Mail1");
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(MailReceiverModel mailReceiverModel)
        {
           Mail mail=new Mail();

            mail.MailName = mailReceiverModel.MailName;
            mail.MailSurname = mailReceiverModel.MailSurname;
            mail.ReceiverMail = mailReceiverModel.ReceiverMail;
            mail.MailTitle = mailReceiverModel.MailTitle;
            mail.MailContent = mailReceiverModel.MailContent;
            mail.MailDate = DateTime.Now;          
            mailManager.TAdd(mail);
            return RedirectToAction("Index", "Product");
        }

    }
    public static class DateTimeExtensions
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalDays > 365)
                return $"{(int)(timeSpan.TotalDays / 365)} yıl önce";
            if (timeSpan.TotalDays > 30)
                return $"{(int)(timeSpan.TotalDays / 30)} ay önce";
            if (timeSpan.TotalDays > 1)
                return $"{(int)timeSpan.TotalDays} gün önce";
            if (timeSpan.TotalHours > 1)
                return $"{(int)timeSpan.TotalHours} saat önce";
            if (timeSpan.TotalMinutes > 1)
                return $"{(int)timeSpan.TotalMinutes} dakika önce";
            if (timeSpan.TotalSeconds > 1)
                return $"{(int)timeSpan.TotalSeconds} saniye önce";

            return "şimdi";
        }
    }

}

