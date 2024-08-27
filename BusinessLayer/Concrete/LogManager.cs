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
    public class LogManager : ILogService
    {
        ILogDal _logDal;

        public LogManager(ILogDal logDal)
        {
            _logDal = logDal;
        }

        public List<Log> GetList()
        {
            return _logDal.GetListAll();
        }

        public void TAdd(Log t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Log t)
        {
            throw new NotImplementedException();
        }

        public Log TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Log t)
        {
            throw new NotImplementedException();
        }
    }
}
