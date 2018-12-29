using Dominio.Aliquota;
using Dominio.Operacao;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infra.Extensions;
using System.IO;

namespace Infra.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Bandeira> Bandeiras { get; set; }
        public DbSet<Adquirente> Adquirentes { get; set; }
        public DbSet<Taxa> Aliquotas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<ItemTransacao> ItensTransacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BandeiraMapping());
            modelBuilder.AddConfiguration(new AdquirenteMapping());
            modelBuilder.AddConfiguration(new AliquotaMapping());
            modelBuilder.AddConfiguration(new TransacaoMapping());
            modelBuilder.AddConfiguration(new ItemTransacaoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (_options == null)
            //{
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //}
            //else
            //{
            //    var dbContextBuilder = new DbContextOptionsBuilder(_options);
            //    optionsBuilder = dbContextBuilder;
            //}
        }
    }
}
