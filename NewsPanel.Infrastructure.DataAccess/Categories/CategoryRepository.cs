﻿using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.Contract.Categories;
using NewsPanel.Infrastructure.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NewsContext newsContext) : base(newsContext)
        {
        }
    }
}
