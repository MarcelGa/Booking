using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Messaging;
using Core.Interfaces.Repositories;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;

namespace RestApi
{
    public class Startup
    {
        private readonly OpenApiSettings openApiSettings = new OpenApiSettings("BookingOpenApiSpecification", "RestAPI","1");
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration);

            ConfigurePersistance(services);
            ConfigureMessagingServices(services);
            ConfigureApiGenerator(services, openApiSettings);

            services.AddMvc(setupAction =>
            {
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

                setupAction.ReturnHttpNotAcceptable = true;

                setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions( o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            IDbInitializer seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(openApiSettings.GetSwaggerUrl(), openApiSettings.Name);
            });

            app.UseMvc();
            
            seeder.Seed().Wait();
        }

        private void ConfigurePersistance(IServiceCollection services)
        {
            services.AddDbContext<EfDbContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
            services.AddScoped<IServiceRepository, EfServiceRepository>();
            services.AddTransient<IDbInitializer, EfDbInitializer>();
        }

        private void ConfigureMessagingServices(IServiceCollection services)
        {
            services.AddScoped<ISmsSender, NullMessageSender>();
            services.AddScoped<IEmailSender, NullMessageSender>();
            services.AddScoped<INotificationSender, NullMessageSender>();
        }

        private void ConfigureApiGenerator(IServiceCollection services, OpenApiSettings settings)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(settings.Name, new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = settings.Title,
                    Version = settings.Version
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFilePath);
            });
        }
    }
}
