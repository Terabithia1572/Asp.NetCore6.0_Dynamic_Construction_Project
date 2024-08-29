using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    
    public class DefaultController : Controller
    {
       
        public PartialViewResult AboutMe()
        {
            return PartialView();
        }

        public PartialViewResult TopBar()
        {
            return PartialView();
        }
        public PartialViewResult WhyUs()
        {
            return PartialView();
        }
        public PartialViewResult UstHeader()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}
