using NewsPanel.Domain.Core.Contract.Common;
using NewsPanel.Domain.Core.NewsEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Domain.Core.Contract.Newss
{
    public interface INewsRepository : IBaseRepository<News>
    {
    }
}
