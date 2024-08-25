using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    public class TestController : Controller
    {
     
       
        public PartialViewResult Scripts()
        {
            return PartialView();
        }
    }
}
