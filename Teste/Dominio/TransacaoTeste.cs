using Dominio.Aliquota;
using Dominio.Operacao;
using System;
using System.Linq;
using Xunit;

namespace Testes
{
    public class TransacaoTeste
    {
        private readonly Taxa _taxa;

        public TransacaoTeste()
        {
            _taxa = new Taxa {
                Id = Guid.NewGuid(),
                Percentual = 0.09
            };
        }

        [Theory]
        [InlineData("1234123412341234", 100, 91, 9, "Cartão: 1234123412341234; Valor Lojista: R$91.00; Valor Adquirente: R$9.00.")]
        [InlineData("5487675590871233", 651.18, 592.57, 58.61, "Cartão: 5487675590871233; Valor Lojista: R$592.57; Valor Adquirente: R$58.61.")]
        public void TestarCriacaoItem(string cartao, double valorTransacao, double valorLojista, double valorAdquirente, string retorno)
        {
            var transacaoFactory = new TransacaoFactory(valorTransacao);
            var transacao = transacaoFactory.Criar();

            transacao.CriarItem(_taxa, cartao, "01/23", "654", valorTransacao);

            Assert.Equal(valorAdquirente, transacao.Transacoes.FirstOrDefault().ValorAdquirente);
            Assert.Equal(valorLojista, transacao.Transacoes.FirstOrDefault().ValorLojista);
            Assert.Equal(retorno, transacao.Transacoes.FirstOrDefault().DescricaoRetorno);
        }

        [Fact]
        public void TestarCriacaoTransacaoFactory()
        {
            var transacaoFactory = new TransacaoFactory(100);
            var transacao = transacaoFactory.Criar();

            Assert.Equal(100, transacao.Valor);
        }

    }
}
