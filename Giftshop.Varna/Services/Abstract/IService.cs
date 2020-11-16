using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public interface IService<TEntity> 
        where TEntity : DatabaseModel
    {
        IEnumerable<TEntity> Get();
        TEntity Get(long id);
        void Save(TEntity entity);
        void Update(long id, TEntity entity);
    }
}