using System;
using System.Linq;
using Dominio.Aliquota;
using Infra.Context;

namespace Infra.Repository
{
    public class AliquotaRepository : Repository<Taxa>, IAliquotaRepository
    {
        protected Contexto _contexto { get; set; }

        public AliquotaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = base._contexto;
        }

        public Taxa ObterPorAdquirenteBandeira(Guid idBandeira, Guid idAdquirente)
        {
            return Obter(x => x.IdBandeira == idBandeira && 
                         x.IdAdquirente == idAdquirente).FirstOrDefault();
        }
    }
}
