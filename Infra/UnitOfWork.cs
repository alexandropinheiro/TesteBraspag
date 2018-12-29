using Dominio;
using Infra.Context;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Commit()
        {
            return _contexto.SaveChanges() > 0;
        }
    }
}
