using Infra.Context;

namespace PDV.Testes.Setup
{
    public static class TestDbContextBuilder
    {
        public static Contexto BuildDbContext()
        {
            return new Contexto(TestDbContextOptionsBuilder.BuildOptions());
        }
    }
}