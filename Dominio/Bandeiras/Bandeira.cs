using Dominio.Base;
using Dominio.Taxas;
using System.Collections.Generic;

namespace Dominio.Bandeiras
{
    public class Bandeira : NomeBase
    {
        public List<Taxa> Taxas { get; set; }
    }
}
