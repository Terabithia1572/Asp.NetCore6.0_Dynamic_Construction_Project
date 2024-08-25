﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using DNTCaptcha.Core;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        CommentManager commentManager = new CommentManager(new EfCommentRepository());
      
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(FileUploadModel fileUploadModel)
        {
            Comment comment = new Comment();
            if (ModelState.IsValid)
            {
                if (!_validatorService.HasRequestValidCaptchaEntry(Language.Turkish, DisplayMode.ShowDigits))
                {
                    this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Lütfen Doğrulama Kodunu Girin.");
                    return RedirectToAction("Index", "Main");
                }
            }
            if (fileUploadModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(fileUploadModel.ImageUrl.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFolder/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                fileUploadModel.ImageUrl.CopyTo(stream);
                comment.ImageUrl = "/ImageFolder/" + newimageName;
            }
            comment.CommentUserName = fileUploadModel.CommentUserName;
            comment.CommentTitle = fileUploadModel.CommentTitle;
            comment.CommentContent = fileUploadModel.CommentContent;
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index", "Main");
        }

        public IActionResult CommentList(int id)
        {
            var values = commentManager.GetList();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var commentValue = commentManager.TGetByID(id);
            commentManager.TDelete(commentValue);
            return RedirectToAction("CommentList", "Comment");
        }
        public IActionResult DeleteComment1(int id)
        {
            var commentValue = commentManager.TGetByID(id);
            commentManager.TDelete(commentValue);
            return RedirectToAction("CardPage", "DashBoard");
        }
        public CommentController(IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options)
        {
            _validatorService = validatorService;

            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
        }
    }
}
