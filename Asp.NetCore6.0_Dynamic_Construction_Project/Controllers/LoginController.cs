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
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, false);
                Log loginLog = new Log
                {
                    UserName = p.username,
                    Date = DateTime.Now,
                    Action = "Giriş Denemesi",
                    Success = result.Succeeded
                };

                _context.Logs.Add(loginLog);
                await _context.SaveChangesAsync();

                if (result.Succeeded)
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
            Log logoutLog = new Log
            {
                UserName = User.Identity.Name,
                Date = DateTime.Now,
                Action = "Çıkış Yaptı",
                Success = true
            };

            _context.Logs.Add(logoutLog);
            await _context.SaveChangesAsync();

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
