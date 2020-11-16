using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Database.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : DatabaseModel
    {
        TEntity Get(long id);

        IEnumerable<TEntity> Get();

        void Save(TEntity entity);

        void Update(TEntity entity);
    }
}
