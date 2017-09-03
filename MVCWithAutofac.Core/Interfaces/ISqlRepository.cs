using MVCWithAutofac.Core.Model;
using System;
namespace MVCWithAutofac.Core.Interfaces
{
    public interface IRepository : IDisposable
    {
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        System.Linq.IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : BaseModel<int>;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity Entity) where TEntity : class;
        System.Linq.IQueryable<TEntity> Search<TEntity>(string searchText) where TEntity : BaseModel<int>;
        void SaveChanges();
    }
}
