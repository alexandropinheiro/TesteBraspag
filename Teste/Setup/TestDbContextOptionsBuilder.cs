using Infra.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Testes.Setup
{
    public static class TestDbContextOptionsBuilder
    {
        public static DbContextOptions<Contexto> BuildOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();

            var sqliteConnection = new SqliteConnection("DataSource=:memory:");
            sqliteConnection.Open();

            optionsBuilder.UseSqlite(sqliteConnection);

            return optionsBuilder.Options;
        }
    }
}