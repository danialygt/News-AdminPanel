using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.CategoryEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Categories
{

    internal class NewsCategoryConfig : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.Property(c => c.NewsId).IsRequired();
            builder.Property(c => c.CatrgotyId).IsRequired();
        }
    }
}
