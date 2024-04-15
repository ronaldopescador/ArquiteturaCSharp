using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigma.Domain.Interfaces.Infra.Data;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;
using Sigma.Infra.Data.Repositories;
using Sigma.Service.Interfaces;
using Sigma.Service.Services;

namespace Sigma.Infra.CrossCutting.IoC
{
    
    public static class ContainerService
    {
        public static IServiceCollection AddApplicationServicesCollentions(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjetoService, ProjetoService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string queryString)
        {
            services.AddDbContext<SigmaContext>(options => options.UseNpgsql(queryString, b => b.MigrationsAssembly("Sigma")));
            return services;
        }

        
    }
}
