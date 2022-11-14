using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
   
    public class EmployeeTaskManager : IEmployeeTaskService
    {

        IEmployeeTaskDAL _employeeTaskDAL;

        public EmployeeTaskManager(IEmployeeTaskDAL employeeTaskDAL)
        {
            _employeeTaskDAL = employeeTaskDAL;
        }

        public void TDelete(EmployeeTask t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTask TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTask> TGEtEmployeeTaskByemployee()
        {
            return _employeeTaskDAL.GEtEmployeeTaskByemployee();
        }

        public List<EmployeeTask> TGEtEmployeeTaskByID(int id)
        {
            return _employeeTaskDAL.GEtEmployeeTaskById(id);
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDAL.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDAL.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            throw new NotImplementedException();
        }
    }
}
