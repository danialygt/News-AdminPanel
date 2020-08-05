using NewsPanel.Domain.Core.NewsEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Domain.Core.KeywordEntities
{
    public class NewsKeyword:BaseEntity
    {
        public int NewsId { get; set; }
        //public News News { get; set; }
        public int KeywordId { get; set; }
        //public Keyword Keyword { get; set; }
    }
}
