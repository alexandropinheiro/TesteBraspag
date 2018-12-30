using Dominio.Aliquota;
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
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraCielo.Id, Percentual = Convert.ToDecimal(0.03) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraElavon.Id, Percentual = Convert.ToDecimal(1.5) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteVisa.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = Convert.ToDecimal(1.07) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraCielo.Id,  Percentual = Convert.ToDecimal(0.02) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraElavon.Id, Percentual = Convert.ToDecimal(1.08) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteMaster.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = Convert.ToDecimal(1.14) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraCielo.Id, Percentual = Convert.ToDecimal(0.01) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraElavon.Id, Percentual = Convert.ToDecimal(0.95) },
                new Taxa { Id = Guid.NewGuid(), IdAdquirente = _adquirenteElo.Id, IdBandeira = _bandeiraGetNet.Id, Percentual = Convert.ToDecimal(1.02) }
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
    }
}
