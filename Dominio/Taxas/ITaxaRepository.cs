using Dominio.Base;
using System;

namespace Dominio.Taxas
{
    public interface ITaxaRepository : IRepositoryBase<Taxa>
    {
        Taxa ObterPorAdquirenteBandeira(Guid idBandeira, Guid idAdquirente);
    }
}
