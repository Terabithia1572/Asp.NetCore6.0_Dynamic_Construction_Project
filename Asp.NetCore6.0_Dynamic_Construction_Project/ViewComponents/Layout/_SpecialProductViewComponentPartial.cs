using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Layout
{
    public class _SpecialProductViewComponentPartial:ViewComponent
    {
        SpecialProductManager SpecialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        public IViewComponentResult Invoke()
        {
            var values=SpecialProductManager.GetList();
            return View(values);
        }
    }
}
