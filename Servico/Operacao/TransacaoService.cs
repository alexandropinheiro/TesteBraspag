using Dominio.Aliquota;
using Dominio.Operacao;
using System;

namespace Servico.Operacao
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITaxaRepository _aliquotaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITaxaRepository aliquotaRepository,
                                ITransacaoRepository transacaoRepository)
        {
            _aliquotaRepository = aliquotaRepository;
            _transacaoRepository = transacaoRepository;
        }

        public void ObterTaxaParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente)
        {
            foreach (var item in transacao.Transacoes)
            {
                var aliquota = _aliquotaRepository.ObterPorAdquirenteBandeira(idBandeira, idAdquirente);
                item.Taxa = aliquota;
            }
        }
    }
}
