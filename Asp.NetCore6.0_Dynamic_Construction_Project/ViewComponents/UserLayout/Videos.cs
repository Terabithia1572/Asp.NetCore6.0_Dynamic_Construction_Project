using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.UserLayout
{
    public class Videos:ViewComponent
    {
        VideoManager videoManager = new VideoManager(new EfVideoRepository());
        public IViewComponentResult Invoke()
        {
            var values = videoManager.GetList();
            return View(values);
        }
    }
}
