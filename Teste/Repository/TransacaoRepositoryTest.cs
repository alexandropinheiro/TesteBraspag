using Dominio;
using Dominio.Aliquota;
using Dominio.Operacao;
using Infra.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Teste.Repository
{
    public class TransacaoRepositoryTest : TesteBase, IDisposable
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

        [Fact]
        public void CalcularTaxaUmCartao()
        {
            var bandeira = _repositoryBandeira.Obter(b => b.Nome.Contains("Cielo")).FirstOrDefault();
            var adquirente = _repositoryAdquirente.Obter(b => b.Nome.Contains("Visa")).FirstOrDefault();

            var taxa = _repositoryTaxa.ObterPorAdquirenteBandeira(bandeira.Id, adquirente.Id);
            taxa.Percentual = Convert.ToDecimal(0.07);

            #region=================== Implementação do teste ==========================

            var transacaoFactory = new TransacaoFactory(180);
            var transacao = transacaoFactory.Criar();

            transacao.CriarItem(taxa,
                                "1234123412341234",
                                "09/22",
                                "782",
                                180);

            var itemTransacao = transacao.Transacoes.FirstOrDefault();

            Assert.Equal("Cartão: 1234123412341234; Valor Lojista: R$167.40; Valor Adquirente: R$12.60.", 
                          itemTransacao.DescricaoRetorno);
            #endregion
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}
