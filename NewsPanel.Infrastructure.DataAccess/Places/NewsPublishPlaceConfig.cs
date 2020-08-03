using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.PlaceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Places
{
    internal class NewsPublishPlaceConfig : IEntityTypeConfiguration<NewsPublishPlace>
    {
        public void Configure(EntityTypeBuilder<NewsPublishPlace> builder)
        {
            builder.Property(c => c.NewsId).IsRequired();
            builder.Property(c => c.PlaceId).IsRequired();
        }
    }
}
