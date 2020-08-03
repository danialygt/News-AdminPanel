using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPanel.Domain.Core.PlaceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Places
{
    internal class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(20).IsRequired();
        }
    }

}
