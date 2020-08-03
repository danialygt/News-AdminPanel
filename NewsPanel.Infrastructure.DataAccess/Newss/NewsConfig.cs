using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.NewsEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Newss
{
    internal class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.File).IsUnicode(false);
            builder.Property(c => c.PublishDate).IsRequired();
        }
    }
}
