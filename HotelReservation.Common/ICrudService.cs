using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace HotelReservation.Common
{
    public interface ICrudService<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity Update(TEntity entity);
        TEntity Create(TEntity entity);
        TEntity Delete(TEntity entity);
       // TEntity Delete(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        DbRawSqlQuery<TX> ExecuteQuery<TX>(string sql, params object[] parameters);
    }
}
