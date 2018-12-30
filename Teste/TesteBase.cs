using Infra.Context;
using PDV.Infra.Setup;
using PDV.Testes.Setup;

namespace Teste
{
    public class TesteNBase
    {
        protected Contexto Contexto;
        protected IDatabaseInitializer databaseInitializer;

        protected void Setup()
        {
            Contexto = TestDbContextBuilder.BuildDbContext();
            databaseInitializer = new DatabaseInitializer(Contexto);

            databaseInitializer.ApplyMigrationsIfPossible();
            databaseInitializer.Seed();
        }

        protected void TearDown()
        {
            Contexto.Database.EnsureDeleted();
            databaseInitializer = null;
        }
    }
}
