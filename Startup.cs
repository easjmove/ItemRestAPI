using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemRestAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ItemRestAPI",
                    Version = "v1",
                    Description = "Best API ever",
                    Contact = new OpenApiContact { Name = "Morten", Email = "move@zealand.dk" }
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "ItemRestAPI v2",
                    Version = "v2",
                    Description = "Best API ever v2",
                    Contact = new OpenApiContact { Name = "Morten", Email = "move@zealand.dk" }
                });
            });

            services.AddCors(options => options.AddPolicy("AllowAll", builder =>
             builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromHours(30))));

            services.AddCors(options => options.AddPolicy("AllowOnlyGet", builder =>
             builder.AllowAnyOrigin().WithMethods("GET").AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromHours(30))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItemRestAPI v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ItemRestAPI v2");
            });


            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
