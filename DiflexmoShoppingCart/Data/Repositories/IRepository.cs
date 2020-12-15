using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeflexmoCart.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Update(T entity);
        void Add(T entity);
        void AddRange(List<T> entities);
        T Detach(T replaceT);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}
