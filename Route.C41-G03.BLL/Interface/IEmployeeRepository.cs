using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Interface
{
    public interface IEmployeeRepository
    {
        IQueryable GetByAddress(string address);
        IQueryable SearchByName(string Name);
    }
}
