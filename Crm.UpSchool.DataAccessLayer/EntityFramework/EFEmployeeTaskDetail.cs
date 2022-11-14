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
    public class EFEmployeeTaskDetail : GenericRepository<EmployeeTaskDetails>, IEmployeeTaskDetailDal
    {
        public List<EmployeeTaskDetails> GetEmployeeTaskDetailById(int id)
        {
            using (var context = new Context()) 
            {
                return context.EmployeeTaskDetails.Where(x => x.EmployeeTaskID == id).ToList();
            }
        }
    }
}
