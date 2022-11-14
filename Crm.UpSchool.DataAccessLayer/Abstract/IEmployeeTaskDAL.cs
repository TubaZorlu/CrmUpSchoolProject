using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Abstract
{
    public interface IEmployeeTaskDAL:IGenericDal<EmployeeTask>
    {
        List<EmployeeTask> GEtEmployeeTaskByemployee();

        List<EmployeeTask> GEtEmployeeTaskById(int id);
    }
}
