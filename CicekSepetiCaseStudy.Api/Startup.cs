using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.Context;
using CicekSepetiCaseStudy.Data.CQRS.Queries.Request;
using CicekSepetiCaseStudy.Data.Services.StockService;
using CicekSepetiCaseStudy.Data.Services.StrockService;
using CicekSepetiCaseStudy.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CicekSepetiCaseStudy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<CartDbContext>(opt => 
                                                 opt.UseInMemoryDatabase(
                                                     databaseName: "cart_db"
                                                     ));  // <<<<<<<<<<<<<
            services.AddDbContext<StockDbContext>(opt =>
                                                 opt.UseInMemoryDatabase(
                                                     databaseName: "stock_db"
                                                     ));  // <<<<<<<<<<<<<

            services.AddScoped<ICartService, CartService>();// <<<<<<<<<<<<< 
            services.AddScoped<IStockService, StockService>();// <<<<<<<<<<<<< 

            services.AddMediatR(typeof(GetAllProductsQuery).GetTypeInfo().Assembly); // https://stackoverflow.com/a/51657748/12579069
                                                                                     //Assembly.GetExecutingAssembly()); // <<<<<<<<<<<<<

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection(); // not to deal with ssl things while deploying to heroku

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });         
        }
    }
}
