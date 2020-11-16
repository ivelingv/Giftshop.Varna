using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
	public abstract class Repository<TEntity> : IRepository<TEntity>
		 where TEntity : DatabaseModel
	{
		protected DatabaseContext Context { get; }

		public Repository(DatabaseContext context)
		{
			Context = context;
		}

		public void Save(TEntity entity)
		{
			entity.CreateDate = entity.CreateDate != System.DateTime.MinValue 
				? entity.CreateDate : System.DateTime.Now;
			entity.UpdateDate = System.DateTime.Now;

			Context.Set<TEntity>().Add(entity);
			Context.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			entity.UpdateDate = System.DateTime.Now;
			Context.Entry(entity).State = EntityState.Modified;
			Context.SaveChanges();
		}

		public TEntity Get(long id)
		{
			return Context.Set<TEntity>()
				.FirstOrDefault(e => e.Id == id);
		}

		public IEnumerable<TEntity> Get()
		{
			return Context.Set<TEntity>()
				.AsQueryable();
		}
	}
}
