using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ElvisApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElvisApi.Database
{
    public class Repository<T> : IRepository<T> where T : BaseEntity//, IEntity
    {
        private readonly DbSet<T> DbSet;
        private readonly DbContext _context;
        
        public Repository(PostgreSqlContext dataContext)
        {
            
            _context = dataContext;
            DbSet = dataContext.Set<T>();
      
        }

        #region IRepository<T> Members

        public T Insert(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            var entry = _context.Entry(entity);
          //  entry.State = System.Data.EntityState.Modified;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            // Beware the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return DbSet.Find(id);
        }



        #endregion
    }
}
