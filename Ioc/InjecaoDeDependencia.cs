using Dominio;
using Dominio.Operacao;
using Dominio.Aliquota;
using Infra.Context;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Ioc.Extensions;

namespace Ioc
{
    public static class InjecaoDeDependencia
    {
        //public static void RegisterServices(IServiceCollection services)
        //{
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //    services.AddScoped<ITaxaRepository, TaxaRepository>();
        //    services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        //    services.AddScoped<IBandeiraRepository, BandeiraRepository>();
        //    services.AddScoped<IAdquirenteRepository, AdquirenteRepository>();
        //    services.AddScoped<Contexto>();
        //}

        public static IServiceCollection RegistrarDependenciasDoIoC(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<Contexto>();

            service.InjetarClassesQueImplementam(typeof(IRepository));

            return service;
        }
    }
}
