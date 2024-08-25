using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.UserLayout
{
    public class SpecialProduct:ViewComponent
    {
        SpecialProductManager _specialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        public IViewComponentResult Invoke()
        {
            var values = _specialProductManager.GetList();
            return View(values);
        }
    }
}
