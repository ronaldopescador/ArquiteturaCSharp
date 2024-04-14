using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Context;
using Projetos.Infra.Data.Repositories;
using Projetos.Service.Interfaces;
using Projetos.Service.Services;

namespace Projetos.Infra.CrossCutting.IoC
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
            services.AddDbContext<ProjetosContext>(options => options.UseNpgsql(queryString, b => b.MigrationsAssembly("Projetos")));
            return services;
        }

        
    }
}
