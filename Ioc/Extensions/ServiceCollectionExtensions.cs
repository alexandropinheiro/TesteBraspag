using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Ioc.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InjetarClassesQueImplementam(this IServiceCollection service, Type interfaceImplementada)
        {
            var todosTipos = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).ToList();

            var todasInterfaces = todosTipos
                .Where(x => !x.IsClass && x.GetInterfaces().Contains(interfaceImplementada)).Select(x => x).ToList();

            foreach (var interfaceType in todasInterfaces)
            {
                var classe = todosTipos.Where(x =>
                    x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(interfaceImplementada) &&
                    x.GetInterfaces().Contains(interfaceType)).Select(x => x).FirstOrDefault();

                if (classe == null)
                    continue;

                service.AddScoped(interfaceType, classe);
            }

            return service;
        }
    }
}
