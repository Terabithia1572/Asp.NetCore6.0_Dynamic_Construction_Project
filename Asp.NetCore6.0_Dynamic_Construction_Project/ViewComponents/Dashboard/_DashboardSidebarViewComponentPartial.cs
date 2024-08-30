using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class _DashboardSidebarViewComponentPartial:ViewComponent
    {
        Context context = new();
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly UserManager<AppUser> _userManager;

        public _DashboardSidebarViewComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;

            var user = await _userManager.FindByNameAsync(username);
          
            var adminID = context.Admins.Where(x => x.Name == username).Select(y => y.AdminID).FirstOrDefault();
           
            var values = adminManager.GetAdminByID(adminID);
            if (user != null)
            {
                // ImageUrl alanını ViewBag'e ekliyoruz
                ViewBag.UserImageUrl = user.ImageUrl;
                ViewBag.UserName = user.NameSurname;


            }

            return View(values);
        }
    }
}
