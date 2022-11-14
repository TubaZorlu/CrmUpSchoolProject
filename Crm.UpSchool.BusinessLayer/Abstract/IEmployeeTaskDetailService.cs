using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Abstract
{
    public interface IEmployeeTaskDetailService:IGenericService<EmployeeTaskDetails>
    {
        List<EmployeeTaskDetails> TGetEmployeeTaskDetailById(int id);
    }
}
