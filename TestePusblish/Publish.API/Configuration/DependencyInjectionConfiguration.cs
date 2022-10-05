using Microsoft.EntityFrameworkCore;
using Publish.Core.Interfaces;
using Publish.Core.Services;
using Publish.Data.Context;
using Publish.Data.MessageBus;
using Publish.Data.Repository;
using Publish.Data.Services;
using Publish.Domain.Interfaces;
using Publish.Domain.Services;

namespace Publish.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            service.AddScoped<IMessageBusService,MessageBusService>();
            service.AddScoped<IParamRabbitMQRepository,ParamRabbitMQRepository>();
            service.AddScoped<IParamRabbitMQService,ParamRabbitMQService>();
            service.AddScoped<IProductRepository,ProductRepository>();
            service.AddScoped<IProductService,ProductService>();
            return service;
        }
    }
}