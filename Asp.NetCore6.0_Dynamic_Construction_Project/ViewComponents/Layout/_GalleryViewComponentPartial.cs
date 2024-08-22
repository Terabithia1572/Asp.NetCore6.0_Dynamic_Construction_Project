using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Layout
{
    public class _GalleryViewComponentPartial:ViewComponent
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        public IViewComponentResult Invoke()
        {
            var values = imageManager.GetList();
            return View(values);
        }
    }
}
