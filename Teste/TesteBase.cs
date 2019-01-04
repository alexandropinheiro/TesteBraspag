using Infra.Context;
using Infra.Setup;
using Testes.Setup;

namespace Teste
{
    public class TesteBase
    {
        protected Contexto Contexto;
        protected IDatabaseInitializer databaseInitializer;

        protected void Setup()
        {
            Contexto = TestDbContextBuilder.BuildDbContext();
            databaseInitializer = new DatabaseInitializer(Contexto);

            databaseInitializer.ApplyDatabase();
        }
    }
}
