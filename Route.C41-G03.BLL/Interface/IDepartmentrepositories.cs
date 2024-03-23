using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Interface
{
    public  interface IDepartmentrepositories
    {

        IEnumerable<Department> GetAll();

        Department GetById(int id);

        int Add(Department department);

        int Update(Department department);

        int Delete(Department department)
    }
}
