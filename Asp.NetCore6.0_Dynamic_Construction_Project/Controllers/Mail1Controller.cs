﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    public class Mail1Controller : Controller
    {
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

