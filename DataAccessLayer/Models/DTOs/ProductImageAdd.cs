using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class ProductImageAdd
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public IFormFile ProductImage { get; set; }
        public string ProductFilter { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; } //ilişkili tabloda
        ////////ilişkili tabloda tutulacak ID
        public Category Category { get; set; }
        public string ExistingImagePath { get; set; }
    }
}
