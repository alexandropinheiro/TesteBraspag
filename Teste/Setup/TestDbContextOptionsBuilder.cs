using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PDV.Testes.Setup
{
    public static class TestDbContextOptionsBuilder
    {
        public static DbContextOptions<Contexto> BuildOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.development.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return optionsBuilder.Options;
        }
    }
}