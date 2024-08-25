﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
   
    public class VideoController : Controller
    {
        VideoManager videoManager = new VideoManager(new EfVideoRepository());
        public IActionResult Index()
        {
            var values = videoManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateVideo(int id)
        {
            var values = videoManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateVideo(Video video)
        {
            video.VideoStatus = true;
            videoManager.TUpdate(video);

            return RedirectToAction("Index", "Video");
        }
    }
}
