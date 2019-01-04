using Infra.Context;

namespace Infra.Setup
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly Contexto _contexto;

        public DatabaseInitializer(Contexto contexto)
        {
            _contexto = contexto;
        }

        public virtual void ApplyDatabase()
        {            
             _contexto.Database.EnsureCreated();
        }        
    }
}