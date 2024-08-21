using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.Layout
{
    public class _CommentViewComponentPartial:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke()
        {
            var values = commentManager.GetList();
            return View(values);
        }
    }
}
