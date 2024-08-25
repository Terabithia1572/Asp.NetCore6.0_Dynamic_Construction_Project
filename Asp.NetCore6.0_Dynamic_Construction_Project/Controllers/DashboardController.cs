using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
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

            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
