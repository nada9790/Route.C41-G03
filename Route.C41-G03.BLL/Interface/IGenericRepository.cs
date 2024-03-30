using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41_G03.BLL.Interface
{
    internal interface IGenericRepository<T> where T : class

    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T item);

        void Update(T item);

        void Delete(T item);
    }
}
