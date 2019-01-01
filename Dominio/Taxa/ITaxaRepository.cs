﻿using Dominio.Base;
using System;

namespace Dominio.Aliquota
{
    public interface ITaxaRepository : IRepositoryBase<Taxa>
    {
        Taxa ObterPorAdquirenteBandeira(Guid idBandeira, Guid idAdquirente);
    }
}