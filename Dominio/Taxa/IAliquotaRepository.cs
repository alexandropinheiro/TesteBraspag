using Dominio.Base;
using System;

namespace Dominio.Aliquota
{
    public interface IAliquotaRepository : IRepositoryBase<Taxa>
    {
        Taxa ObterPorAdquirenteBandeira(Guid idBandeira, Guid idAdquirente);
    }
}
