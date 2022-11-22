using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
    public class AnnouncmentManager : IAnnouncmentService
    {
       private readonly IAnnouncmentDal _announcmentDal;

        public AnnouncmentManager(IAnnouncmentDal announcmentDal)
        {
            _announcmentDal = announcmentDal;
        }

        public List<Announcment> TContainA()
        {
            return _announcmentDal.ContainA();
        }

        public void TDelete(Announcment t)
        {
            _announcmentDal.Delete(t);
        }

        public Announcment TGetByID(int id)
        {
            return _announcmentDal.GetByID(id);
        }

        public List<Announcment> TGetList()
        {
            return _announcmentDal.GetList();
        }

        public void TInsert(Announcment t)
        {
            _announcmentDal.Insert(t);
        }

        public void TUpdate(Announcment t)
        {
            _announcmentDal.Update(t);
        }
    }
}
