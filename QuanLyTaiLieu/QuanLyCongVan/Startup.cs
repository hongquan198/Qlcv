using CuaHangBanLe.Repository;
using CuaHangBanLe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QuanLyTaiLieu.Repository;
using QuanLyTaiLieu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTaiLieu
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanLiTaiLieu", Version = "v1" });
            });

            services.AddDbContext<QuanLyCongVanDBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            services.AddScoped(typeof(IRepositoryAccount<>), typeof(RepositoryAccount<>));
            services.AddScoped(typeof(IRepositoryDocument<>), typeof(RepositoryDocument<>));
            services.AddScoped(typeof(IRepositoryNumberDoc<>), typeof(RepositoryNumberDoc<>));
            services.AddScoped(typeof(IRepositoryPlaceDoc<>), typeof(RepositoryPlaceDoc<>));
            services.AddScoped(typeof(IRepositoryTypeDoc<>), typeof(RepositoryTypeDoc<>));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<INumberDocService, NumberDocService>();
            services.AddScoped<IPlaceDocService, PlaceDocService>();
            services.AddScoped<ITypeDocService, TypeDocService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true) // allow any origin
       .AllowCredentials()); // allow credentials\\


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuanLiTaiLieu v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
