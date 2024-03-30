using Route.C41_G03DAL.Data;
using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Repositories
{
    internal class EmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {

        }

        public IQueryable GetByAddress(string address)
        {
            return _dbContext.Set<Employee>().Where(E => E.Address == address);
        }

        public IQueryable SearchByName(string Name)
        {
            return _dbContext.Set<Employee>().Where(E => E.Name.Contains(Name));
        }
    }
}
