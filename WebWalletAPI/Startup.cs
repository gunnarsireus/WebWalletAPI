﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebWalletAPI.Data;

namespace WebWalletAPI
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
	        services.AddDbContext<WebWalletApiContext>(options =>
		        options.UseSqlite("DataSource=App_Data/WebWallet.db"));

			services.AddMvc();

	        // Register the Swagger generator, defining one or more Swagger documents
	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1", new Info { Title = "WebWalletAPI", Version = "v1" });
	        });
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        // Enable middleware to serve generated Swagger as a JSON endpoint.
	        app.UseSwagger();

	        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebWalletAPI V1");
	        });

			app.UseMvc();
        }
    }
}
