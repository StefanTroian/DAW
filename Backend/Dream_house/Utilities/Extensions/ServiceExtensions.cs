using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Repositories.DatabaseRepository;
using Dream_house.Services.DemoService;
using Microsoft.Extensions.DependencyInjection;

namespace Dream_house.Utilities.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDemoService, DemoService>();

            return services;
        }
    }
}
