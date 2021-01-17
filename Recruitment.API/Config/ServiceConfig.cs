using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruitment.Core.Interfaces;
using Recruitment.Core.Interfaces.Manager;
using Recruitment.Core.Interfaces.Validation;
using Recruitment.Core.Managers;
using Recruitment.Core.Services;
using Recruitment.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.API.Config
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection,IConfiguration config)
        {
            serviceCollection.AddHttpClient<IFunctionService, FunctionService>(
                u => u.BaseAddress = new Uri(config.GetSection("FunctionAPI").Value ) );

        }

        public static void ConfigureMangers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHashManager, HashManager>();
        }


        public static void ConfigureValidations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRequestValidation, RequestValidation>();
        }

    }
}
