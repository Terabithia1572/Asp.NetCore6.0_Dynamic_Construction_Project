using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class _DashboardNavbarViewComponentPartial:ViewComponent
    {
        Context context = new();
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly UserManager<AppUser> _userManager;

        public _DashboardNavbarViewComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var userProfile = context.Admins.Where(x => x.Username == username).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v4 = userProfile;
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription;
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                // ImageUrl alanını ViewBag'e ekliyoruz
                ViewBag.UserImageUrl = user.ImageUrl;
                ViewBag.UserName = user.NameSurname;


            }
            var values = adminManager.GetAdminByID(adminID);

            return View(values);
        }
    }
}
