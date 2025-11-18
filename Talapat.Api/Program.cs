
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Talabat.Core.IRepositories;
using Talapat.Api.Extensions;
using Talapat.Api.Helpers;
using Talapat.Api.Middlewares;
using Talapat.Repository.Data;
using Talapat.Repository.Repositories;

namespace Talapat.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);
            #region Configure Services

            // Add services to the Dependence Injection container.

            webApplicationBuilder.Services.AddControllers();
            webApplicationBuilder.Services.AddSwaggerServices();


            webApplicationBuilder.Services.AddTransient<ProductPictureURLResolver>();
            webApplicationBuilder.Services.AddDbContext<TalabatDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            webApplicationBuilder.Services.AddApplicationServices();
            #endregion

            var app = webApplicationBuilder.Build();
             using var scope = app.Services.CreateScope();

            var service = scope.ServiceProvider;
            var _dbContext = service.GetRequiredService<TalabatDbContext>();
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await TalabatDbContextSeed.SeedAsync(_dbContext);

            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migration");
            }
            #region Configure Kesteral Middelwares

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }
            
            app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
