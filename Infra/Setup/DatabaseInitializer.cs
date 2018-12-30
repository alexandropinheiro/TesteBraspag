using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Infra.Context;
using Infra.Mapping;

namespace PDV.Infra.Setup
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly Contexto _contexto;

        public DatabaseInitializer(Contexto contexto)
        {
            _contexto = contexto;
        }

        public virtual bool ApplyMigrationsIfPossible()
        {
            var applied = _contexto.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = _contexto.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            var allMigrationsApplied = !total.Except(applied).Any();

            if (allMigrationsApplied) return false;
            
            if (!_contexto.Database.EnsureCreated())
                _contexto.Database.Migrate();

            return true;
        }

        public virtual void Seed()
        {
            foreach (var t in _contexto.Taxas)
                _contexto.Remove(t);

            foreach (var b in _contexto.Bandeiras)
                _contexto.Remove(b);

            foreach (var a in _contexto.Adquirentes)
                _contexto.Remove(a);

            _contexto.AddRange(EntitySeeder.Bandeiras());
            _contexto.AddRange(EntitySeeder.Adquirentes());
            _contexto.AddRange(EntitySeeder.Taxas());
            _contexto.SaveChanges();
        }
    }
}