using Infra.Context;

namespace Testes.Setup
{
    public static class TestDbContextBuilder
    {
        public static Contexto BuildDbContext()
        {
            return new Contexto(TestDbContextOptionsBuilder.BuildOptions());
        }
    }
}