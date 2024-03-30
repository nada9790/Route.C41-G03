using Route.C41_G03DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Repositories
{
    internal class GenericRepository <T> where T : class
    {
        private protected readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T item)
        => dbContext.Add(item);


        public void Delete(T item)
       => dbContext.Remove(item);




        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)dbContext.Employees.Include(E => E.department).ToList();
            }

            return dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        => dbContext.Set<T>().Find(id);


        public void Update(T item)
       => dbContext.Update(item);


    }
}
