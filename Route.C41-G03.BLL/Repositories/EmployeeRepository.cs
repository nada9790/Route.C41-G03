using Microsoft.EntityFrameworkCore;
using Route.C41_G03.BLL.Interface;
using Route.C41_G03DAL.Data;
using Route.C41_G03DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _dbContext.Employees.Where(e => EF.Functions.Like(e.Address, address)); //e.Address.ToLower() == address.ToLower()
        }
    }
}
