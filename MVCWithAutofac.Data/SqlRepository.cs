using MVCWithAutofac.Core.Interfaces;
using MVCWithAutofac.Core.Model;
using System;
using System.Data.Entity;
using System.Linq;


namespace MVCWithAutofac.Data
{
    public class SqlRepository : IRepository
    {
        private readonly IDbContext context;

        public SqlRepository(IDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetEntities<TEntity>().AsQueryable();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntities<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntities<TEntity>().Remove(entity);
        }

        private IDbSet<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }


        public TEntity GetById<TEntity>(int id) where TEntity : BaseModel<int>
        {
            return (from item in GetAll<TEntity>()
                    where item.Id == id
                    select item).SingleOrDefault();
        }



        public void Update<TEntity>(TEntity Entity) where TEntity : class
        {
            var newcontext = new EFContext("TaxBackMVCWithAutofacDB");
            newcontext.Entry<TEntity>(Entity).State = System.Data.Entity.EntityState.Modified;

            newcontext.SaveChanges();
        }


        public IQueryable<TEntity> Search<TEntity>(string searchText) where TEntity : BaseModel<int>
        {

            return (from item in GetAll<TEntity>()
                    where item.Description.Contains(searchText)
                    select item).AsQueryable();
        }

    }
}