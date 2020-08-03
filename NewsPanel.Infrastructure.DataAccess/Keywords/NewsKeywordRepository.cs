using NewsPanel.Domain.Core.Contract.Keywords;
using NewsPanel.Domain.Core.KeywordEntities;
using NewsPanel.Infrastructure.DataAccess.Common;

namespace NewsPanel.Infrastructure.DataAccess.Keywords
{

    public class NewsKeywordRepository : BaseRepository<NewsKeyword>, INewsKeywordRepository
    {
        public NewsKeywordRepository(NewsContext newsContext) : base(newsContext)
        {
        }
    }
}
