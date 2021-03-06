﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPanel.Domain.Core.Contract.Common
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity, new()
    {
        TEntity Add(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        TEntity Get(int id);
        TEntity Get(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Save();
    }
}


