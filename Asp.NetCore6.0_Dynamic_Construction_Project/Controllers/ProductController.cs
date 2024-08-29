using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using Asp.NetCore6._0_Dynamic_Construction_Project.ViewComponents.UserLayout;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
    
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
        public IActionResult ProductList()
        {
           

            var values = productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
        
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductImageAdd productImageAdd)
        {
            Product product = new Product();
            if (productImageAdd.ProductImage != null)
            {
                var extension = Path.GetExtension(productImageAdd.ProductImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                productImageAdd.ProductImage.CopyTo(stream);
                product.ProductImage = "/ProductImage/" + newimageName;
            }

            string[] rastgeleFiltre = new string[3];
            rastgeleFiltre[0] = "filter-starters";
            rastgeleFiltre[1] = "filter-salads";
            rastgeleFiltre[2] = "filter-specialty";
            Random r = new Random();
            int sayi = r.Next(0, 3);
            product.ProductStatus = true;
            product.ProductFilter = rastgeleFiltre[sayi];
            product.ProductName = productImageAdd.ProductName;
            product.ProductDescription= productImageAdd.ProductDescription;
            product.ProductPrice = productImageAdd.ProductPrice;
            product.CategoryID = productImageAdd.CategoryID;
            productManager.TAdd(product);
            return RedirectToAction("ProductList", "Product");
        }

        public IActionResult DeleteProduct(int id)
        {
            var blogvalue = productManager.TGetByID(id);
            productManager.TDelete(blogvalue);
            return RedirectToAction("ProductList", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = productManager.TGetByID(id);

            if (product == null)
            {
                return NotFound();
            }

            // Kategorileri listelemek için mevcut kodu kullanıyoruz
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            // Product nesnesini view modeline dönüştürüyoruz
            ProductImageUpdate productImageAdd = new ProductImageUpdate
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                CategoryID = product.CategoryID,
                ExistingImagePath = product.ProductImage // Mevcut resim yolunu alıyoruz
            };

            return View(productImageAdd);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductImageUpdate productImageAdd)
        {
            var product = productManager.TGetByID(productImageAdd.ProductID);

            if (product == null)
            {
                return NotFound();
            }

            if (productImageAdd.ProductImage != null)
            {
                var extension = Path.GetExtension(productImageAdd.ProductImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                productImageAdd.ProductImage.CopyTo(stream);
                product.ProductImage = "/ProductImage/" + newimageName;
            }
            else
            {
                product.ProductImage = productImageAdd.ExistingImagePath; // Mevcut resmi koruyoruz
            }

            product.ProductName = productImageAdd.ProductName;
            product.ProductDescription = productImageAdd.ProductDescription;
            product.ProductPrice = productImageAdd.ProductPrice;
            product.CategoryID = productImageAdd.CategoryID;
            product.ProductStatus = true; // Durumu güncelliyoruz

            productManager.TUpdate(product);

            return RedirectToAction("ProductList", "Product");
        }

    }
}
