using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using AutoMapper;
using React.Json.AppServices.AutoMapper;
using React.Json.IoC;
using React.Json.CrossCutting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using React.Json.Api.Middleware;
using System;

namespace React.Json.Api
{
    public class Startup
    {
        private IHostingEnvironment enviroment;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            enviroment = env;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connections
            ConnectionStrings.JsonConnection = Configuration.GetConnectionString("JsonConnection");
            
            //Log
            Environment.SetEnvironmentVariable("LogHostName", Configuration.GetSection("AppConfiguration")["LogHostName"]);
            Environment.SetEnvironmentVariable("LogUsername", Configuration.GetSection("AppConfiguration")["LogUsername"]);
            Environment.SetEnvironmentVariable("LogPassword", Configuration.GetSection("AppConfiguration")["LogPassword"]);
            Environment.SetEnvironmentVariable("LogExchangeNameRabbit", Configuration.GetSection("AppConfiguration")["LogExchangeNameRabbit"]);
            Environment.SetEnvironmentVariable("RequestExchangeNameRabbit", Configuration.GetSection("AppConfiguration")["RequestExchangeNameRabbit"]);

            //services.AuthenticationAPI(enviroment);

            if (enviroment.IsStaging() || enviroment.IsProduction())
            {
                services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
            }
            else
            {
                services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.Formatting = Formatting.Indented;
                    });
            }

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Cliente", policy => policy.RequireClaim("Perfil", "Cliente"));
            });

           
            services.AddAutoMapper();
            AutoMapperConfiguration.RegisterMappings();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = $"Json API {enviroment.EnvironmentName}", Version = "v1", Description = "Projeto Json responsável por fornecer dados aos sistemas da React" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Swagger.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddOptions();

            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // Registrar todos os DI
            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "React Json API");
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.InjectOnCompleteJavaScript("/swagger-js/swagger-bearer-auth.js");
            });

            app.UseAuthentication();
            app.UseSwagger();
            //app.UseRequestMonitoring();
            app.UseMiddleware<UserMiddleware>();
            app.UseMvc();

            //Swagger Default Router
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
