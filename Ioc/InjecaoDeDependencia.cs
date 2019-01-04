using Dominio;
using Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Ioc.Extensions;

namespace Ioc
{
    public static class InjecaoDeDependencia
    {        
        public static IServiceCollection RegistrarDependenciasDoIoC(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<Contexto>();

            service.InjetarClassesQueImplementam(typeof(IRepository));

            return service;
        }
    }
}
