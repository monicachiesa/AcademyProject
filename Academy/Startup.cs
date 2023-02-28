using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Academy.Models;
using Academy.Services;
using Microsoft.Extensions.Options;

namespace Academy
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();

        //    services.AddDbContext<Contexto>(options =>
        //       options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
        //   ));

        //    services.AddScoped<IAlunoService, AlunosService>(); //registra o servi�o

        //    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //    services.AddCors(c => c.AddDefaultPolicy(builder =>
        //    {
        //        builder.AllowAnyOrigin()
        //               .AllowAnyMethod()
        //               .AllowAnyHeader();
        //    }));

        //}
        public void ConfigureServices(IServiceCollection services)
        {
            // Other DI initializations
         services.AddDbContext<Contexto>(options =>
                    options.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=DatabaseAcademia;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
