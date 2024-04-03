using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Models
{
    public class Department:ModelBase
    {
        public int Id { get; set; } //primary key 

        public string Code { get; set; }
        
        public string Name { get; set; }
        [Display (Name= "Date Of Cereation")]
        public DateTime DateOfCereation{ get; set; }= DateTime.Now;

        //Navigational Property
        [InverseProperty(nameof(Employee.department))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
