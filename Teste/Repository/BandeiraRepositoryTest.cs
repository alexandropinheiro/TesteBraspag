using Dominio.Bandeiras;
using Infra.Repository;
using Xunit;

namespace Teste.Repository
{
    public class BandeiraRepositoryTest: TesteBase
    {
        private IBandeiraRepository _bandeiraRepository;

        public BandeiraRepositoryTest()
        {
            Setup();
            _bandeiraRepository = new BandeiraRepository(Contexto);
        }

        [Fact(DisplayName = "Listar as bandeiras da carga inicial do sistema.")]
        public void ListarBandeiras()
        {
            var bandeiras = _bandeiraRepository.ObterTodos();

            Assert.True(bandeiras.Count == 3);

            bandeiras.ForEach(b =>
            {
                var bandeirasEsperadas = "VisaMasterElo";
                Assert.True(bandeirasEsperadas.IndexOf(b.Nome) > -1);
            });
        }
    }
}
