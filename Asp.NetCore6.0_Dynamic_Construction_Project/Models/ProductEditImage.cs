namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class ProductEditImage
    {
        public static string ImageAdd(IFormFile image, string Folder)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + Folder,
                newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return Folder + newImageName;
        }
        public static string StaticProfileImageLocation()
        {
            return "/ProductImage/";
        }
        public static string StaticAboutImageLocation()
        {
            return "/ProductUploadImage/";
        }
    }
}
