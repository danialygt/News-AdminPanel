using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.KeywordEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Keywords
{


    internal class KeywordConfig : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(30).IsRequired();
        }
    }
}
