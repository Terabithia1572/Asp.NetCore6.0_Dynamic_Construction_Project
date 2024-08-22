using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Layout
{
    public class _OrganizationViewComponentPartial:ViewComponent
    {
        OrganizationManager organizationManager = new OrganizationManager(new EfOrganizationRepository());
        public IViewComponentResult Invoke()
        {
            var values = organizationManager.GetList();
            return View(values);
        }
    }
}
