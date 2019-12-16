// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace Fundoo
{
    using System;
    using System.Reflection;
    using System.IO;
    using BussinessLayer.Interface;
    using BussinessLayer.Services;
    using Common.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Services;
    using Swashbuckle.AspNetCore.Swagger;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using System.Collections.Generic;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Routing;
    using AutoMapper;

    /// using AutoMapper;

    // using AutoMapper;
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddAutoMapper();
            services.AddTransient<IBussinessRegister, BussinessRegister>();
            services.AddTransient<IRepository, RegisterRepository>();

            services.AddTransient<IBussinessNotes, BussinessNotes>();
            services.AddTransient<IRepositoryNotes, RepositoryNotes>();

            services.AddTransient<IBussinessLabel, BussinessLabel>();
            services.AddTransient<IRepositoryLabel, RepositoryLabel>();

            services.AddTransient<IAdminSignUpBussiness, AdminSignUpBussiness>();
            services.AddTransient<IAdminSignUpRepository, AdminSignUpRepository>();


            /// this is connetcion string 
           /// OptionsConfigurationServiceCollectionExtensions.Configure<DatabaseConnection>(services, Configuration("ConnectionStrings:connectionDb");

            services.AddDbContext<ContextData>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionDb")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

          //  services.AddAutoMapper();

            services.AddDefaultIdentity<ApplicationModel>()
                 .AddEntityFrameworkStores<ContextData>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                // Your custom configuration
                c.SwaggerDoc("v1", new Info { Title = "FundooNotes API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
               {
               {"Bearer",new string[]{}}
               });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000")
                    );
            });

            
           
            /// Authentication code
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(g =>
            {
                g.RequireHttpsMetadata = false;
                g.SaveToken = false;
                g.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:Key"])),
                   
                };

            });

        }

        /// <summary>
        /// Configures the specified application.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
             

            app.UseCors("CorsPolicy");
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundoo Api");
            });

        }
    }

   
}


