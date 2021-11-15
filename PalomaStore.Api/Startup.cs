using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PalomaStore.Domain.StoreContext.Handlers;
using PalomaStore.Domain.StoreContext.Repositories;
using PalomaStore.Domain.StoreContext.Services;
using PalomaStore.Infra.DataContext;
using PalomaStore.Infra.StoreContext.Repositories;
using PalomaStore.Infra.StoreContext.Services;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using PalomaStore.Shared;

namespace PalomaStore.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }  

        public void ConfigureServices(IServiceCollection services)
        {
             var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

           Configuration = builder.Build();    

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();

            services.AddResponseCompression();
            
            services.AddScoped<PalomaDataContext, PalomaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Paloma Store", Version = "v1"});
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "7aaffb2d4d304909ad47e837f6ce849f";
                o.LogId = new Guid("0af99e5d-fdfb-4722-8826-15cf82cef87c");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
        
            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paloma Store - V1");
            });

            app.UseElmahIo();
        }        
    }
}
