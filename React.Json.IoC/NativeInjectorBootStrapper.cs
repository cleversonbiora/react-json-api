using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using React.Json.AppServices.Interfaces;
using React.Json.AppServices.Services;
using React.Json.CrossCutting.Util;
using React.Json.Domain.Interfaces;
using React.Json.Domain.Repositories;
using React.Json.Domain.Services;
using React.Json.Infra.Repositories;

namespace React.Json.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

			//Page
			services.AddTransient<IPageAppService, PageAppService>();
			services.AddTransient<IPageService, PageService>();
			services.AddTransient<IPageRepository, PageRepository>();

			//Template
			services.AddTransient<ITemplateAppService, TemplateAppService>();
			services.AddTransient<ITemplateService, TemplateService>();
			services.AddTransient<ITemplateRepository, TemplateRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));



            //Domain Services
            services.AddScoped<IJsonAttributeService, JsonAttributeService>();
            services.AddScoped<IJsonNodeService, JsonNodeService>();

            //Infra
            services.AddScoped<IJsonNodeRepository, JsonNodeRepository>();
            services.AddScoped<IJsonAttributeRepository, JsonAttributeRepository>();

            services.AddSingleton<UsuarioLogado>();
        }
    }
}
