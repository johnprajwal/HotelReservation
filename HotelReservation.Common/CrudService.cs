using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace HotelReservation.Common
{
    public class CrudService<TEntity> : IDisposable, ICrudService<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;

        public CrudService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            var dbSet = _dbContext.Set<TEntity>();
            if (dbSet.Local.All(e => e != entity))
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entityToDelete = _dbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete == null)
            {
                throw new Exception("Not Found");
            }

            _dbContext.Set<TEntity>().Remove(entityToDelete);
            _dbContext.SaveChanges();
            return entityToDelete;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public DbRawSqlQuery<TX> ExecuteQuery<TX>(string sql, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<TX>(sql, parameters);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
