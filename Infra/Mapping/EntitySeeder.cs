using Dominio.Aliquota;
using Infra.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Infra.Mapping
{
    public static class EntitySeeder
    {
        #region Bandeiras
        private static readonly Bandeira _bandeiraCielo = new Bandeira { Id = Guid.NewGuid(), Nome = "Cielo" };
        private static readonly Bandeira _bandeiraElavon = new Bandeira { Id = Guid.NewGuid(), Nome = "Elavon" };
        private static readonly Bandeira _bandeiraGetNet = new Bandeira { Id = Guid.NewGuid(), Nome = "GetNet" };
        #endregion

        #region Adquirentes
        private static readonly Adquirente _adquirenteVisa = new Adquirente { Id = Guid.NewGuid(), Nome = "Visa" };
        private static readonly Adquirente _adquirenteMaster = new Adquirente { Id = Guid.NewGuid(), Nome = "Master" };
        private static readonly Adquirente _adquirenteElo = new Adquirente { Id = Guid.NewGuid(), Nome = "Elo" };
        #endregion
        
        public static List<Bandeira> Bandeiras()
        {
            return new List<Bandeira>
            {
                _bandeiraCielo,
                _bandeiraElavon,
                _bandeiraGetNet
            };
        }

        public static List<Adquirente> Adquirentes()
        {
            return new List<Adquirente>
            {
                _adquirenteElo,
                _adquirenteVisa,
                _adquirenteMaster
            };
        }

        public static List<Taxa> Taxas()
        {
            return new List<Taxa> {
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraCielo.Id, Percentual = 0.0003 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraElavon.Id, Percentual = 0.015 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = 0.0107 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraCielo.Id,  Percentual = 0.0002 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraElavon.Id, Percentual = 0.0108 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = 0.0114 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraCielo.Id, Percentual = 0.0001 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraElavon.Id, Percentual = 0.0095 },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = 0.0102 }
            };
        }

        public static void Seed(this EntityTypeBuilder<Bandeira> builder)
        {
            builder.HasData(Bandeiras());
        }

        public static void Seed(this EntityTypeBuilder<Adquirente> builder)
        {
            builder.HasData(Adquirentes());
        }

        public static void Seed(this EntityTypeBuilder<Taxa> builder)
        {
            builder.HasData(Taxas());

        }

        public static void Iniatize(this Contexto context)
        {
            context.Database.EnsureCreated();
        }
    }
}
