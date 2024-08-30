using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{

    public class SpecialProductController : Controller
    {
        SpecialProductManager specialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SpecialProductList()
        {

            var values = specialProductManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSpecialProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialProduct(SpecialProductImages specialProductImages)
        {
            SpecialProduct specialProduct = new SpecialProduct();
            if (specialProductImages.SpecialProductImage != null)
            {
                var extension = Path.GetExtension(specialProductImages.SpecialProductImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SpecialProductImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                specialProductImages.SpecialProductImage.CopyTo(stream);
                specialProduct.SpecialProductImage = "/SpecialProductImage/" + newimageName;
            }
            Random r = new Random();
            int sayi = r.Next(8, 100);
            specialProduct.SpecialProductTabIndex = "tab-" + sayi;
            specialProduct.SpecialProductStatus = "";
            specialProduct.SpecialProductContent = specialProductImages.SpecialProductContent;
            specialProduct.SpecialProductTitle = specialProductImages.SpecialProductTitle;
            specialProductManager.TAdd(specialProduct);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }

        public IActionResult DeleteSpecialProduct(int id)
        {
            var productvalue = specialProductManager.TGetByID(id);
            specialProductManager.TDelete(productvalue);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }
        [HttpGet]
        public IActionResult EditSpecialProduct(int id)
        {

            var productvalues = specialProductManager.TGetByID(id);
            if (productvalues == null)
            {
                return NotFound();
            }
            SpecialProductImages specialProductImages = new SpecialProductImages
            {
                SpecialProductID = productvalues.SpecialProductID,
                SpecialProductTitle = productvalues.SpecialProductTitle,
                SpecialProductContent = productvalues.SpecialProductContent,
                SpecialProductStatus = productvalues.SpecialProductStatus,
                SpecialProductTabIndex = productvalues.SpecialProductTabIndex,
                ExistingImagePath = productvalues.SpecialProductImage // Mevcut resim yolunu alıyoruz
            };

            return View(specialProductImages);
        }
        [HttpPost]
        public IActionResult EditSpecialProduct(SpecialProductImages specialProductImages)
        {
            var specialProduct = specialProductManager.TGetByID(specialProductImages.SpecialProductID);
            if (specialProduct == null)
            {
                return NotFound();
            }

            if (specialProductImages.SpecialProductImage != null)
            {
                var extension = Path.GetExtension(specialProductImages.SpecialProductImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SpecialProductImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                specialProductImages.SpecialProductImage.CopyTo(stream);
                specialProduct.SpecialProductImage = "/SpecialProductImage/" + newimageName;
            }
            else
            {
                specialProduct.SpecialProductImage = specialProductImages.ExistingImagePath; // Mevcut resmi koruyoruz
            }

            Random r = new Random();
            int sayi = r.Next(8, 100);
            specialProduct.SpecialProductTabIndex = "tab-" + sayi;
            specialProduct.SpecialProductStatus = "";
            specialProduct.SpecialProductTitle = specialProductImages.SpecialProductTitle;
            specialProduct.SpecialProductContent = specialProductImages.SpecialProductContent;

            specialProductManager.TUpdate(specialProduct);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }
    }
    }
