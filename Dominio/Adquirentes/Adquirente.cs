using Dominio.Base;
using Dominio.Taxas;
using System.Collections.Generic;

namespace Dominio.Adquirentes
{
    public class Adquirente : NomeBase
    {
        public ICollection<Taxa> Taxas { get; set; }
    }
}
