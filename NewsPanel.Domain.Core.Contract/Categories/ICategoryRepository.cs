using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.Contract.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Domain.Core.Contract.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
