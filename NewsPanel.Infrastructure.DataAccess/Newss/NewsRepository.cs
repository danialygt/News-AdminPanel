using NewsPanel.Domain.Core.Contract.Newss;
using NewsPanel.Domain.Core.NewsEntity;
using NewsPanel.Infrastructure.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Newss
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(NewsContext newsContext) : base(newsContext)
        {
        }
    }
}
