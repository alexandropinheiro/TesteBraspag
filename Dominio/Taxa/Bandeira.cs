using Dominio.Base;
using System.Collections.Generic;

namespace Dominio.Aliquota
{
    public class Bandeira : NomeBase
    {
        public List<Taxa> Aliquotas { get; set; }
    }
}
