using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class AdminDashBoardCategory:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            Random r = new Random();
            int sayi = r.Next(25, 100);
            ViewBag.Random = sayi.ToString();
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
