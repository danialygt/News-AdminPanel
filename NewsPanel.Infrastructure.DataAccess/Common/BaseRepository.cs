using NewsPanel.Domain.Core;
using NewsPanel.Domain.Core.Contract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()

    {
        private readonly NewsContext _newsContext;

        public BaseRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public TEntity Add(TEntity entity)
        {
            _newsContext.Set<TEntity>().Add(entity);
            _newsContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity()
            {
                Id = id
            };
            _newsContext.Remove(entity);
            _newsContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _newsContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _newsContext.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            _newsContext.Set<TEntity>().Update(entity);
            _newsContext.SaveChanges();
        }

        public void Update(int id)
        {
            var entity = Get(id);
            Update(entity);
        }
    }
}
