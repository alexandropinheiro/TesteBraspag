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
        public DbSet<Taxa> Taxas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<ItemTransacao> ItensTransacao { get; set; }

        private readonly DbContextOptions _options;

        public Contexto() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BandeiraMapping());
            modelBuilder.AddConfiguration(new AdquirenteMapping());
            modelBuilder.AddConfiguration(new TaxaMapping());
            modelBuilder.AddConfiguration(new TransacaoMapping());
            modelBuilder.AddConfiguration(new ItemTransacaoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseSqlServer(config.GetConnectionString("Azure"));                
            }
            else
            {
                var dbContextBuilder = new DbContextOptionsBuilder(_options);
                optionsBuilder = dbContextBuilder;
            }
        }
    }
}
