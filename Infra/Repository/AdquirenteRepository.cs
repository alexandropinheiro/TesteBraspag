using Dominio.Aliquota;
using Infra.Context;

namespace Infra.Repository
{
    public class AdquirenteRepository : Repository<Adquirente>, IAdquirenteRepository
    {
        public AdquirenteRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
