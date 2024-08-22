using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Layout
{
    public class _EmployeeViewComponentPartial:ViewComponent
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        public IViewComponentResult Invoke()
        {
            var values = employeeManager.GetList();
            return View(values);
        }
    }
}
