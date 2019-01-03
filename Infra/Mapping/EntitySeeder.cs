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
        private static readonly Adquirente _adquirenteCielo = new Adquirente { Id = Guid.NewGuid(), Nome = "Cielo" };
        private static readonly Adquirente _adquirenteElavon = new Adquirente { Id = Guid.NewGuid(), Nome = "Elavon" };
        private static readonly Adquirente _adquirenteGetNet = new Adquirente { Id = Guid.NewGuid(), Nome = "GetNet" };
        #endregion

        #region Adquirentes
        private static readonly Bandeira _bandeiraVisa = new Bandeira { Id = Guid.NewGuid(), Nome = "Visa" };
        private static readonly Bandeira _bandeiraMaster = new Bandeira { Id = Guid.NewGuid(), Nome = "Master" };
        private static readonly Bandeira _bandeiraElo = new Bandeira { Id = Guid.NewGuid(), Nome = "Elo" };
        #endregion
        
        public static List<Adquirente> Adquirentes()
        {
            return new List<Adquirente>
            {
                _adquirenteCielo,
                _adquirenteElavon,
                _adquirenteGetNet
            };
        }

        public static List<Bandeira> Bandeiras()
        {
            return new List<Bandeira>
            {
                _bandeiraElo,
                _bandeiraVisa,
                _bandeiraMaster
            };
        }

        public static List<Taxa> Taxas()
        {
            return new List<Taxa> {
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraVisa.Id, IdAdquirente = _adquirenteCielo.Id, Percentual = 0.0003 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraVisa.Id, IdAdquirente = _adquirenteElavon.Id, Percentual = 0.015 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraVisa.Id, IdAdquirente = _adquirenteGetNet.Id, Percentual = 0.0107 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraMaster.Id, IdAdquirente = _adquirenteCielo.Id,  Percentual = 0.0002 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraMaster.Id, IdAdquirente = _adquirenteElavon.Id, Percentual = 0.0108 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraMaster.Id, IdAdquirente = _adquirenteGetNet.Id, Percentual = 0.0114 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraElo.Id, IdAdquirente = _adquirenteCielo.Id, Percentual = 0.0001 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraElo.Id, IdAdquirente = _adquirenteElavon.Id, Percentual = 0.0095 },
                new Taxa { Id = Guid.NewGuid(), IdBandeira = _bandeiraElo.Id, IdAdquirente = _adquirenteGetNet.Id, Percentual = 0.0102 }
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
