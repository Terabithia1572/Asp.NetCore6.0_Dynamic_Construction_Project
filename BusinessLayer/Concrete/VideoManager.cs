using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VideoManager : IVideoService
    {
        public List<Video> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Video t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Video t)
        {
            throw new NotImplementedException();
        }

        public Video TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Video t)
        {
            throw new NotImplementedException();
        }
    }
}
