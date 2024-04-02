using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Route.C41_G03DAL.Models
{
   public enum Gender
    {
        [EnumMember(Value="Male")]
        Male= 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }
    public enum EmpType
    {
        FullTime=1,
        PartTime=2
    }
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Maximum Length Of Name Is 50 Chars")]
        [MinLength(5, ErrorMessage = "Minimum Length Of Name Is 5 Chars")]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{4,10}"
        ,ErrorMessage ="Address Must That As 123-Street-City-Country")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name="Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display (Name="PhoneNumber")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name="Hiring Date")]
        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }= false;
      

        //forignKey
        [ForeignKey(nameof(department))]
        public int? DeptId { get; set; }

        //Navigational property [one]
        [InverseProperty(nameof(Department.Employees))]
        public virtual Department department { get; set; } = null!;
    }
}
