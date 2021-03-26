using Repo.Factories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositores
{
    public class CommonRepository<TEntity> : IDisposable where TEntity : class
    {
        protected internal readonly DbContext _dbContext;
        protected internal readonly DbSet<TEntity> _dbSet;
        public CommonRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext), "The parameter dbContext can not be null");
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }
        public T Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T item = _dbContext.Set<T>().FirstOrDefault(predicate);
            return item;
        }
        public IEnumerable<T> Query<T>(string sql) where T : class
        {
            return this._dbContext.Database.SqlQuery<T>(sql).ToList();
        }
        public void Delete<T>(long key) where T : class
        {
            var existing = this._dbContext.Set<T>().Find(key);

            if (existing != null)
            {
                _dbContext.Entry(existing).State = System.Data.Entity.EntityState.Deleted;
                this._dbContext.SaveChanges();
            }

        }
        public T Add<T>(T t) where T : class
        {
            if (t == null)
                return null;

            try
            {
                this._dbContext.Set<T>().Add(t);
                this._dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                new HelperFactory().LogtoSQL2(ex, "CommonRepository=>Add", "");
            }
            return t;
        }
        public T Save<T>(T updated, long key) where T : class
        {
            if (updated == null)
                return null;
            try
            {
                _dbContext.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                new HelperFactory().LogtoSQL2(ex, "CommonRepository=>Save", "");
            }
            return updated;
        }
    }
}
