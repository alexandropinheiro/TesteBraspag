using Dominio.Base;
using System.Collections.Generic;

namespace Dominio.Aliquota
{
    public class Adquirente : NomeBase
    {
        public ICollection<Taxa> Taxas { get; set; }
    }
}
