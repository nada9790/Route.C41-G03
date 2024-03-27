﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Models
{
    public enum Gender 
    {
        Male= 1,

        Female= 2
    }

     public enum EmpType 
    {
        FullTime=1,
        PartTime=2
    }


    public class Employee
    {
        
        [Required(ErrorMessage = "Name Is Required !!")]
        [MaxLength(50, ErrorMessage = "Max Length Of Name Must Be 50")]
        [MinLength(5, ErrorMessage = "Min Length Of Name Must Be 5")]
        public string Name { get; set; }
        [Range(22, 30)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
                  , ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        //last 2 property just for backend development to mapping..not display in frontend
        public bool IsDeleted { get; set; }//hard delete(delete from database)..soft delete(delete employee from database...isDeleted is true value ..this record still موجود )
        public DateTime CreationDate { get; set; }

        //navigation property (one)
        //[InverseProperty(nameof(Models.Department.Employees))]
        public Department Department { get; set; }
        //[ForeignKey("Department")]
        public int? DepartmentId { get; set; } //forgini key
    }
}
