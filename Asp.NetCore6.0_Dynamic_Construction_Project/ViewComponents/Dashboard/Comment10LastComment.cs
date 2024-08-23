using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Dashboard
{
    public class Comment10LastComment:ViewComponent
    {

        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = commentManager.GetList();
            return View(values);
        }
    }
}
