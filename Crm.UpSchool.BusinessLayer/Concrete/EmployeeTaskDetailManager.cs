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
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }

        public void TDelete(EmployeeTaskDetails t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTaskDetails TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTaskDetails> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetails> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(EmployeeTaskDetails t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EmployeeTaskDetails t)
        {
            throw new NotImplementedException();
        }
    }
}
