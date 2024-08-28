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
    public class MailManager : IMailService
    {
        IMailDal _mailDal;
        public List<Mail> GetList()
        {
            return _mailDal.GetListAll();
        }

        public void TAdd(Mail t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Mail t)
        {
            _mailDal.Delete(t);
        }

        public Mail TGetByID(int id)
        {
            return _mailDal.GetByID(id);
        }

        public void TUpdate(Mail t)
        {
            throw new NotImplementedException();
        }
    }
}
