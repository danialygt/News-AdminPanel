using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Domain.Core.NewsEntity
{
    public class News: BaseEntity
    {
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }



        public List<NewsKeyword> Keyword { get; set; }
        public List<NewsCategory> Category { get; set; }
        public List<NewsPublishPlace> PublishPlace { get; set; }
    }
}
