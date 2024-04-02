using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Fluent APIs for "Employee " Domain
            builder.Property(E => E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.Property(E=>E.Address).IsRequired();
            builder.Property(E => E.Salary).HasColumnType("decimal(12,12)");
            builder.Property(E => E.Gender)
                .HasConversion(
                 (Gender) => Gender.ToString(),
                 (genderAsString) => (Gender)Enum.Parse(typeof(Gender), genderAsString, true));

        }

       
    }   
}
