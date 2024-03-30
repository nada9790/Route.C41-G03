using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Models
{
    internal class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Maximum Length of name 50")]
        [MinLength(5, ErrorMessage = "Minimum Length of name 50")]
        public string Name { get; set; }

        //[RegularExpression("^[0-9]{1-3}-[a-zA-Z]{4-10}-[a-zA-Z]{3-10}-[a-zA-Z]{4-10}",ErrorMessage ="Address Must That As 123-Street-City-Country")]
        public string Address { get; set; }


        public decimal Salary { get; set; }

        public bool IsActive { get; set; }


        public string Email { get; set; }


        public int Gender { get; set; }


        public string PhoneNumber { get; set; }


        //forignKey
        [ForeignKey(nameof(department))]
        public int? DeptId { get; set; }

        //Navigational property [one]
        [InverseProperty(nameof(Department.Employees))]
        public virtual Department department { get; set; } = null!;
    }
}
