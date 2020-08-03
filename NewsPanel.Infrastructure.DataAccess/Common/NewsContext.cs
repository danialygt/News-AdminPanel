using Microsoft.EntityFrameworkCore;
using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.KeywordEntities;
using NewsPanel.Domain.Core.NewsEntity;
using NewsPanel.Domain.Core.PlaceEntities;
using NewsPanel.Infrastructure.DataAccess.Categories;
using NewsPanel.Infrastructure.DataAccess.Keywords;
using NewsPanel.Infrastructure.DataAccess.Newss;
using NewsPanel.Infrastructure.DataAccess.Places;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Common
{
    public class NewsContext:DbContext
    {
       


        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<NewsPublishPlace> newsPublishPlaces { get; set; }
        public DbSet<Keyword> keywords { get; set; }
        public DbSet<NewsKeyword> newsKeywords { get; set; }




        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new NewsCategoryConfig());
            modelBuilder.ApplyConfiguration(new KeywordConfig());
            modelBuilder.ApplyConfiguration(new NewsKeywordConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new PlaceConfig());
            modelBuilder.ApplyConfiguration(new NewsPublishPlaceConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}

