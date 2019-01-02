using Dominio.Aliquota;
using Dominio.Operacao;
using System;

namespace Servico.Operacao
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITaxaRepository _taxaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITaxaRepository taxaRepository,
                                ITransacaoRepository transacaoRepository)
        {
            _taxaRepository = taxaRepository;
            _transacaoRepository = transacaoRepository;
        }

        public void ObterTaxaParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente)
        {
            foreach (var item in transacao.Transacoes)
            {
                var taxa = _taxaRepository.ObterPorAdquirenteBandeira(idBandeira, idAdquirente);
                item.Taxa = taxa;
            }
        }
    }
}
