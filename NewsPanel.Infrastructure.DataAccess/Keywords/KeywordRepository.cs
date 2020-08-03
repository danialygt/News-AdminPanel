using NewsPanel.Domain.Core.Contract.Keywords;
using NewsPanel.Domain.Core.KeywordEntities;
using NewsPanel.Infrastructure.DataAccess.Common;

namespace NewsPanel.Infrastructure.DataAccess.Keywords
{
    public class KeywordRepository : BaseRepository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(NewsContext newsContext) : base(newsContext)
        {
        }
    }
}
