using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElvisApi.Database;
using ElvisApi.Database.Entities;
using ElvisApi.Service;
using ElvisApi.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace ElvisApi
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });

            // services.AddDbContext<PostgreSqlContext>(options =>
            //    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<PostgreSqlContext>(options => options.UseInMemoryDatabase(databaseName: "postgres"));
           services.AddMvc();


            services.AddScoped<PostgreSqlContext>();
            services.AddScoped<IRepository<Statement>, Repository<Statement>>();
            services.AddScoped<IStatementService, StatementService>();


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

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(x => x
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true)); // allow any origin
            // .AllowCredentials()); // allow credentials

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

   
    }
}
