using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrganizationManager : IOrganizationService
    {
        public List<Organization> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Organization t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Organization t)
        {
            throw new NotImplementedException();
        }

        public Organization TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Organization t)
        {
            throw new NotImplementedException();
        }
    }
}
