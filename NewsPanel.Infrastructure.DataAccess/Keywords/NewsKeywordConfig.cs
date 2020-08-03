using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.KeywordEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Keywords
{
    internal class NewsKeywordConfig : IEntityTypeConfiguration<NewsKeyword>
    {
        public void Configure(EntityTypeBuilder<NewsKeyword> builder)
        {
            builder.Property(c => c.NewsId).IsRequired();
            builder.Property(c => c.KeywordId).IsRequired();
        }
    }
}
