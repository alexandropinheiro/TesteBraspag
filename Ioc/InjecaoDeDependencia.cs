using Dominio;
using Dominio.Operacao;
using Dominio.Aliquota;
using Infra.Context;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Ioc
{
    public static class InjecaoDeDependencia
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAliquotaRepository, AliquotaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<Contexto>();
        }
    }
}
