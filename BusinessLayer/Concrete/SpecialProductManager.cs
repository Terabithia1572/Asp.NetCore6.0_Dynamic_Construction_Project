using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpecialProductManager : ISpecialProductService
    {
        public List<SpecialProduct> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(SpecialProduct t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SpecialProduct t)
        {
            throw new NotImplementedException();
        }

        public SpecialProduct TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SpecialProduct t)
        {
            throw new NotImplementedException();
        }
    }
}
