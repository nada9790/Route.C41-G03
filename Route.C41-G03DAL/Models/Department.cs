using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03DAL.Models
{
    internal class Department
    {
        public int Id { get; set; } //primary key 

        public string Code { get; set; }
        
        public string Name { get; set; }

        public DateTime DateOfCereation{ get; set; }= DateTime.Now;
    }
}
