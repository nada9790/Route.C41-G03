using Route.C41_G03.BLL.Interface;
using Route.C41_G03DAL.Data;
using Route.C41_G03DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext dbContext;

        private Hashtable ObjectRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            //EmployeeRepository= new EmployeeRepository(dbContext);
            //DepartmentRepository= new DepartmentRepository(dbContext);
            this.dbContext = dbContext;
            ObjectRepository = new Hashtable();
        }
        //public IEmployeeRepository EmployeeRepository { get; set ; }
        //public IDepartmentRepository DepartmentRepository { get ; set; }

        public int Complete => dbContext.SaveChanges();

        public void Dispose()
        => dbContext.Dispose();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var Key = typeof(T).Name;

            if (!ObjectRepository.ContainsKey(Key))
            {
                if (Key == nameof(Employee))
                {
                    var repository = new EmployeeRepository(dbContext);
                    ObjectRepository.Add(Key, repository);
                }
                else
                {
                    var repository = new GenericRepository<T>(dbContext);
                    ObjectRepository.Add(Key, repository);
                }


            }

            return new GenericRepository<T>(dbContext);
        }
    }
}
