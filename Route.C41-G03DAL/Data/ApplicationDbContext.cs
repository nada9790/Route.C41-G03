using Microsoft.EntityFrameworkCore;
using Route.C41_G03DAL.Data.Configurations;
using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>().HasOne(e => e.department).WithMany(d => d.Employees).HasForeignKey(d => d.DeptId)/*.OnDelete(DeleteBehavior.Cascade)*/;




        }
    }
  }
 