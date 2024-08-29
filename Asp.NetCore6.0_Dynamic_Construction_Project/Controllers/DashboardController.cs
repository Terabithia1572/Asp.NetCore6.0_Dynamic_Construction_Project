using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
   
    public class DashboardController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CardPage()
        {
           
            var toplamurunSayisi = productManager.GetList().Count();
            ViewBag.ToplamUrunSayisi = toplamurunSayisi;
            var toplamresimSayisi = imageManager.GetList().Count();
            ViewBag.ToplamResimSayisi = toplamresimSayisi;
            var toplamYorumSayisi = commentManager.GetList().Count();
            ViewBag.ToplamYorumSayisi = toplamYorumSayisi;
            return View();
        }
        public IActionResult Test()
        {

            var toplamurunSayisi = productManager.GetList().Count();
            ViewBag.ToplamUrunSayisi = toplamurunSayisi;
            var toplamresimSayisi = imageManager.GetList().Count();
            ViewBag.ToplamResimSayisi = toplamresimSayisi;
            var toplamYorumSayisi = commentManager.GetList().Count();
            ViewBag.ToplamYorumSayisi = toplamYorumSayisi;
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
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
