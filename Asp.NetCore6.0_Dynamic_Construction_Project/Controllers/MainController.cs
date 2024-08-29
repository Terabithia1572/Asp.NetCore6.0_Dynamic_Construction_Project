using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
