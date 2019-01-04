using Dominio.Adquirentes;
using Dominio.Bandeiras;
using Dominio.Base;
using Dominio.Operacao;
using System;
using System.Collections.Generic;

namespace Dominio.Taxas
{
    public class Taxa: EntidadeBase
    {
        public Guid IdAdquirente { get; set; }
        public Guid IdBandeira { get; set; }
        
        public double Percentual { get; set; }

        public Adquirente Adquirente { get; set; }
        public Bandeira Bandeira { get; set; }

        public List<ItemTransacao> Transacoes { get; set; }
    }
}
