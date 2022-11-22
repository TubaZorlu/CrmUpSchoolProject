using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Repository;
using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EFAnnouncmentDal : GenericRepository<Announcment>, IAnnouncmentDal
    {
        public List<Announcment> ContainA()
        {
            using (var context = new Context()) 
            {
                var values = context.Announcments.Where(x => x.Title.Contains("a")).ToList();
                return values;
            }
        }
    }
}
