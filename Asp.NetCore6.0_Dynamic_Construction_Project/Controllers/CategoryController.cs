using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            categoryManager.TAdd(category);
            return RedirectToAction("CategoryList", "Category");
        }
        public IActionResult CategoryList()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            categoryManager.TDelete(values);
            return RedirectToAction("CategoryList", "Category");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            categoryManager.TUpdate(category);

            return RedirectToAction("CategoryList", "Category");

        }
    }
}
