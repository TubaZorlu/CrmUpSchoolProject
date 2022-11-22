using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services) 
        {

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDAL, EFEmployeeTaskDAL>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EFEmployeeTaskDetail>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IAnnouncmentService, AnnouncmentManager>();
            services.AddScoped<IAnnouncmentDal, EFAnnouncmentDal>();
        }

    }
}
