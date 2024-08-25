using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.UserLayout
{
    public class Images:ViewComponent
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        public IViewComponentResult Invoke(int page = 1)
        {
            var values = imageManager.GetList()
                          .OrderByDescending(x => x.ImageID) // Listeyi Id'ye göre tersten sırala (en son eklenen en üstte olacak)
                          .Take(8)                      // Son 8 öğeyi al
                          .ToList();
            return View(values);
        }
    }
}
