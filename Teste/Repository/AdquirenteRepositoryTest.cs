using Dominio.Adquirentes;
using Infra.Repository;
using Xunit;

namespace Teste.Repository
{
    public class AdquirenteRepositoryTest: TesteBase
    {
        private IAdquirenteRepository _adquirenteRepository;

        public AdquirenteRepositoryTest()
        {
            Setup();
            _adquirenteRepository = new AdquirenteRepository(Contexto);
        }

        [Fact(DisplayName = "Listar os adquirentes da carga inicial do sistema.")]
        public void ListarAdquirentes()
        {
            var adquirentes = _adquirenteRepository.ObterTodos();

            Assert.True(adquirentes.Count == 3);

            adquirentes.ForEach(b =>
            {
                var adquirentesEsperados = "CieloElavonGetNet";
                Assert.True(adquirentesEsperados.IndexOf(b.Nome) > -1);
            });
        }
    }
}
