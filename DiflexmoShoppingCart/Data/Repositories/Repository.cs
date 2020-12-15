using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using DeflexmoCart.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiflexmoShoppingCart.Models;

namespace DeflexmoCart.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IHaveId
    {
        protected DbSet<T> Entities { get; set; }

        private readonly DiflexmoCartDb _context;

        public Repository(DiflexmoCartDb context)
        {
            Entities = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            Entities.AddRange(entities);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public T Detach(T replaceT)
        {
            var originalT = Entities.FirstOrDefault(entry => entry.Id.Equals(replaceT.Id));

            if (originalT != null)
            {
                _context.Entry(originalT).State = EntityState.Detached;
            }

            _context.Entry(replaceT).State = EntityState.Modified;

            return replaceT;
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public void Update(T entity)
        {
            //
        }
    }
}
