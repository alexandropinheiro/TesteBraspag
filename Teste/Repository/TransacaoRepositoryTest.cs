using Dominio;
using Dominio.Aliquota;
using Dominio.Operacao;
using Infra.Repository;
using Repository;
using System.Linq;
using Xunit;

namespace Teste.Repository
{
    public class TransacaoRepositoryTest : TesteBase
    {
        private ITransacaoRepository _repositoryTransacao;
        private IBandeiraRepository _repositoryBandeira;
        private IAdquirenteRepository _repositoryAdquirente;
        private ITaxaRepository _repositoryTaxa;
        private readonly IUnitOfWork _uow;

        public TransacaoRepositoryTest()
        {
            Setup();
            _repositoryTransacao = new TransacaoRepository(Contexto);
            _repositoryTaxa = new TaxaRepository(Contexto);
            _repositoryBandeira = new BandeiraRepository(Contexto);
            _repositoryAdquirente = new AdquirenteRepository(Contexto);
            _uow = new UnitOfWork(Contexto);
        }

        [Fact(DisplayName = "Calcular taxa para um cartão.")]
        public void CalcularTaxaUmCartao()
        {
            var bandeira = _repositoryBandeira.Obter(b => b.Nome.Contains("Visa")).FirstOrDefault();
            var adquirente = _repositoryAdquirente.Obter(b => b.Nome.Contains("Cielo")).FirstOrDefault();

            var taxa = _repositoryTaxa.ObterPorAdquirenteBandeira(bandeira.Id, adquirente.Id);
            taxa.Percentual = 0.0007;

            #region=================== Implementação do teste ==========================

            var transacaoFactory = new TransacaoFactory(180);
            var transacao = transacaoFactory.Criar();

            transacao.CriarItem(taxa,
                                "1234123412341234",
                                "09/22",
                                "782",
                                180);

            var itemTransacao = transacao.Transacoes.FirstOrDefault();

            Assert.Equal("Cartão: 1234123412341234; Valor Lojista: R$179.87; Valor Adquirente: R$0.13.", 
                          itemTransacao.DescricaoRetorno);
            #endregion
        }

        [Fact(DisplayName = "Calcular taxas para dois cartões.")]
        public void CalcularTaxaDoisCartao()
        {
            var bandeiraVisa = _repositoryBandeira.Obter(b => b.Nome.Contains("Visa")).FirstOrDefault();
            var adquirenteCielo = _repositoryAdquirente.Obter(b => b.Nome.Contains("Cielo")).FirstOrDefault();

            var bandeiraElo = _repositoryBandeira.Obter(b => b.Nome.Contains("Elo")).FirstOrDefault();
            var adquirenteGetNet = _repositoryAdquirente.Obter(b => b.Nome.Contains("GetNet")).FirstOrDefault();

            var taxa1 = _repositoryTaxa.ObterPorAdquirenteBandeira(bandeiraVisa.Id, adquirenteCielo.Id);
            taxa1.Percentual = 0.028;

            var taxa2 = _repositoryTaxa.ObterPorAdquirenteBandeira(bandeiraElo.Id, adquirenteGetNet.Id);
            taxa2.Percentual = 0.013;

            #region=================== Implementação do teste ==========================

            var transacaoFactory = new TransacaoFactory(250);
            var transacao = transacaoFactory.Criar();

            transacao.CriarItem(taxa1,
                                "1234123412341234",
                                "09/22",
                                "782",
                                100);

            transacao.CriarItem(taxa2,
                                "9876987698769876",
                                "12/25",
                                "231",
                                150);

            Assert.Equal(2, transacao.Transacoes.Count);

            var i = 1;
            foreach(var item in transacao.Transacoes)
            {
                switch (i)
                {
                    case 1:
                        Assert.Equal("Cartão: 1234123412341234; Valor Lojista: R$97.20; Valor Adquirente: R$2.80.",
                          item.DescricaoRetorno);
                        break;

                    case 2:
                        Assert.Equal("Cartão: 9876987698769876; Valor Lojista: R$148.05; Valor Adquirente: R$1.95.",
                          item.DescricaoRetorno);
                        break;
                }
                i++;
            }
            #endregion
        }
    }
}
