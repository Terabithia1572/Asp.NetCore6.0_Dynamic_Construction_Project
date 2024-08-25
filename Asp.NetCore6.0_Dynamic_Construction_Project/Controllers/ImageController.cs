﻿using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    [AllowAnonymous]
    public class ImageController : Controller
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());

        public IActionResult Index()
        {
            var values = imageManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(ImageUploadModel imageUploadModel)
        {
            Image image = new Image();

            if (imageUploadModel.ImageUpload != null)
            {
                var extension = Path.GetExtension(imageUploadModel.ImageUpload.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WorkImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                imageUploadModel.ImageUpload.CopyTo(stream);
                image.ImageUpload = "/WorkImage/" + newimageName;
            }

            image.ImageStatus = true;
            imageManager.TAdd(image);
            return RedirectToAction("Index", "Image");
        }
        public IActionResult DeleteImage(int id)
        {
            var imageValue = imageManager.TGetByID(id);
            imageManager.TDelete(imageValue);
            return RedirectToAction("Index", "Image");
        }

        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
          
            var values = imageManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateImage(Image image, IFormFile imagefile)
        {
            if (imagefile != null)
            {
                image.ImageUpload = AddImagePage.ImageAdd(imagefile, AddImagePage.StaticProfileImageLocation());
            }
            image.ImageStatus = true;
            imageManager.TUpdate(image);
            return RedirectToAction("Index", "Image");
        }
    }
}
