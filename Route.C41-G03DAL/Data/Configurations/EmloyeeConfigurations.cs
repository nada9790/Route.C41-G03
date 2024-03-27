using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Data.Configurations
{
    internal class EmloyeeConfigurations:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            throw new NotImplementedException();
        }

        public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                //fluent api
                builder.Property(E => E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
                builder.Property(E => E.Address).IsRequired();
                builder.Property(E => E.Salary).HasColumnType("decimal(18 , 2)");

            }
        }
    }
}
