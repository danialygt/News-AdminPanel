using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsPanel.Domain.Core.Contract.Categories;
using NewsPanel.Domain.Core.Contract.Keywords;
using NewsPanel.Domain.Core.Contract.Newss;
using NewsPanel.Domain.Core.Contract.Places;
using NewsPanel.Infrastructure.DataAccess.Categories;
using NewsPanel.Infrastructure.DataAccess.Common;
using NewsPanel.Infrastructure.DataAccess.Keywords;
using NewsPanel.Infrastructure.DataAccess.Newss;
using NewsPanel.Infrastructure.DataAccess.Places;

namespace NewsPanel.EndPoints.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            services.AddDbContext<NewsContext>(c => c.UseSqlServer(Configuration.GetConnectionString("NewsDB")));
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<INewsKeywordRepository, NewsKeywordRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<INewsPublishPlaceRepository, NewsPublishPlaceRepository>();



        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/News/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=News}/{action=List}/{id?}");
            });
        }
    }
}
