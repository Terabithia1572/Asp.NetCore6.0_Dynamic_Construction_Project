using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context context = new();
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task< IActionResult> Index(UserSignInViewModel p)
        {
           
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Test", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Login");


        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
