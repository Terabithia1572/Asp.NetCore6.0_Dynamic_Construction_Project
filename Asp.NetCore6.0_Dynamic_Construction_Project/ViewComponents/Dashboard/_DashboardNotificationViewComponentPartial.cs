using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class _DashboardNotificationViewComponentPartial:ViewComponent
    {
        MailManager mailManager = new MailManager(new EfMailRepository());
        public IViewComponentResult Invoke()
        {
            
            var values = mailManager.GetList()
                         .OrderByDescending(x => x.MailID) // Listeyi Id'ye göre tersten sırala (en son eklenen en üstte olacak)
                         .Take(3)                      // Son 3 öğeyi al
                         .ToList();
            return View(values);
        }
    }
}
