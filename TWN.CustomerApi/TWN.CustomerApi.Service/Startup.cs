using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using TWN.CustomerApi.Infrastructure.ObjectDataContext;
using TWN.CustomerApi.Infrastructure.Repository;
using TWN.CustomerApi.Service.AutoMapper;
using TWN.CustomerApi.Service.Middleware;

namespace TWN.CustomerApi.Service
{
    /// <summary>
    /// Class Startup
    /// </summary>
    public class Startup
    {
        #region Constructors
        /// <summary>
        /// Constructor class Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }
        #endregion Constructors

        /// <summary>
        /// Configuration Variable 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method Configure Services which configure each service defined in the application 
        /// using DI pattern by native Net Core system.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            var config = new MapperConfiguration(cfg => {

                cfg.AddProfile(new MappingProfile());
            } );
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            // Confguring DBContext using services layer
            services.AddDbContext<TestDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DockerDataBase"));
            });

            #region SwaggerService

            // To get information of these versions and endpoints.
            // Nuget package which provides the metadata for the APIs based on how they are decorated
            services.AddApiVersioning(setup =>
            {
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Customer System API",
                    Description = "A simple example ASP.NET Core Web API"
                });
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "ApiKey",
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
                        },
                        new string[] { }
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "TWN.CustomerApi.Service.xml");
                c.IncludeXmlComments(xmlPath);
            });

            #endregion SwaggerService
        }

        /// <summary>
        /// Configure Method where We can modify the middleware pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ApiKeyMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region SwaggerUI

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",description.GroupName.ToUpperInvariant());
                }
            });

            #endregion SwaggerUI
        }
    }
}
