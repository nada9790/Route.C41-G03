using Route.C41_G03.BLL.Interface;
using Route.C41_G03DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Repositories
{
    internal class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            EmployeeRepository = new EmployeeRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            this.dbContext = dbContext;
        }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        => dbContext.Dispose();
    }
}
