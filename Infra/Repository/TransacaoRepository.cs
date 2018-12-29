using Dominio.Operacao;
using Infra.Context;

namespace Infra.Repository
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
