using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Infrastructure.DataAccess.Common
{
    public class NewsContextFactory : IDesignTimeDbContextFactory<NewsContext>
    {
        public NewsContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NewsContext>();
            builder.UseSqlServer("Server=.;Database=NewsDb;Integrated Security=True;MultipleActiveResultSets=true");
            return new NewsContext(builder.Options);
        }
    }
}
