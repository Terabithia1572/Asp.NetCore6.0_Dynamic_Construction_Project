using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{

    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();


        public RegisterUserController(UserManager<AppUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Profil fotoğrafını kaydet
                string uniqueFileName = null;

                if (model.ProfileImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "RegisterImage");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProfileImage.CopyTo(fileStream);
                    }
                }

                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NameSurname = model.NameSurname,
                    ImageUrl = "/RegisterImage/" + uniqueFileName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Kullanıcıyı otomatik olarak giriş yaptırabiliriz veya başka bir sayfaya yönlendirebiliriz.
                    return RedirectToAction("Test", "Dashboard");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Eğer bu noktaya gelirse, sayfayı tekrar göster ve hataları bildir
            return View(model);
        }
    

    }
}
