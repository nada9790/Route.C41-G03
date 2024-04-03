using Route.C41_G03.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Interface
{
   public interface IUnitOfWork
    {
        //public IEmployeeRepository EmployeeRepository { get; }
        //public IDepartmentRepository DepartmentRepository { get; }
        IGenericRepository<T> Repository<T>() where T : class;

        int Complete { get; }
    }
}
