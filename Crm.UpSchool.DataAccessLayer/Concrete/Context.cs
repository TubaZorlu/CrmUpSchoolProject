using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CJELTSN\\MSSQLSERVER2019; Database=DbCRM;integrated security=True;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskDetails> EmployeeTaskDetails { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Announcment> Announcments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
 


    }
}
