using System.Reflection;
using AutoMapper;
using AzureFunctions.TestApplication.Application.Common.Validation;
using AzureFunctions.TestApplication.Application.Implementation;
using AzureFunctions.TestApplication.Application.Interfaces;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace AzureFunctions.TestApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IListedUnlistedServicesService, ListedUnlistedServicesService>();
            services.AddTransient<ISampleDomainsService, SampleDomainsService>();
            services.AddTransient<IValidationService, ValidationService>();
            return services;
        }
    }
}