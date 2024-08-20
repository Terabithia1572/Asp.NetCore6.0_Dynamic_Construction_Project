using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _IImagedal;

        public ImageManager(IImageDal ıImagedal)
        {
            _IImagedal = ıImagedal;
        }

        public List<Image> GetList()
        {
           return _IImagedal.GetListAll();
        }

        public void TAdd(Image t)
        {
            _IImagedal.Insert(t);
        }

        public void TDelete(Image t)
        {
           _IImagedal.Delete(t);
        }

        public Image TGetByID(int id)
        {
            return _IImagedal.GetByID(id);
        }

        public void TUpdate(Image t)
        {
            _IImagedal.Update(t);
        }
    }
}
