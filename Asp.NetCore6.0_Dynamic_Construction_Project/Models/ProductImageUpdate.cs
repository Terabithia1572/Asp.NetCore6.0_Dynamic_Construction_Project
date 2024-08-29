using EntityLayer.Concrete;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class ProductImageUpdate
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
