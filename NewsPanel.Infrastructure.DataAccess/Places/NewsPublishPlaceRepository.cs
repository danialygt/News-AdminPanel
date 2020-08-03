using NewsPanel.Domain.Core.Contract.Places;
using NewsPanel.Domain.Core.PlaceEntities;
using NewsPanel.Infrastructure.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Places
{
    public class NewsPublishPlaceRepository : BaseRepository<NewsPublishPlace>, INewsPublishPlaceRepository
    {
        public NewsPublishPlaceRepository(NewsContext newsContext) : base(newsContext)
        {
        }
    }
}
