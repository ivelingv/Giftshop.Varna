using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public abstract class Service<TRepository, TEntity> : IService<TEntity> 
        where TRepository : IRepository<TEntity>
        where TEntity : DatabaseModel
    {
        protected TRepository Repository { get; }

        protected Service(TRepository repository)
        {
            Repository = repository;
        }

        public virtual TEntity Get(long id)
        {
            return Repository.Get(id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return Repository.Get();
        }

        public virtual void Update(long id, TEntity entity)
        {
            if (id != entity.Id)
            {
                throw new System.Exception("Invalid identifier specified.");
            }

            Repository.Update(entity);
        }

        public virtual void Save(TEntity entity)
        {
            Repository.Save(entity);
        }
    }
}
