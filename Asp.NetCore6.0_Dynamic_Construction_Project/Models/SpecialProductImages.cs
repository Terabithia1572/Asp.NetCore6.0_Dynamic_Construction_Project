namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class SpecialProductImages
    {
        public int SpecialProductID { get; set; }
        public string SpecialProductTitle { get; set; }
        public string SpecialProductContent { get; set; }
        public IFormFile SpecialProductImage { get; set; }
        public string SpecialProductTabIndex { get; set; }
        public string SpecialProductStatus { get; set; }
        public string ExistingImagePath { get; set; }
    }
}
