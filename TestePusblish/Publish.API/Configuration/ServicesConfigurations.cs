using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publish.API.Configuration
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => !p.IsDynamic));
            
            return services;
        }
    }
}