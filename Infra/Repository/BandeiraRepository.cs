using Dominio.Bandeiras;
using Infra.Context;

namespace Infra.Repository
{
    public class BandeiraRepository : Repository<Bandeira>, IBandeiraRepository
    {
        public BandeiraRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
