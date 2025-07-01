using HepsiburadaApi.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using MediatR;
using HepsiburadaApi.Application.Behaviors;
using HepsiburadaApi.Application.Features.Products.Rules;
using HepsiburadaApi.Application.Bases;


namespace HepsiburadaApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr"); 

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        //tüm Rules ları teker teker buraya bulup kaydetmektense BaseRules dan türemiş olanları bulup kaydetmesini sağladık
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type) 
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);
                return services;
        }
    }
}
