using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class _DashboardSidebarViewComponentPartial:ViewComponent
    {
        Context context = new();
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
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
            var values = adminManager.GetAdminByID(adminID);

            return View(values);
        }
    }
}
