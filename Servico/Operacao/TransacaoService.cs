using Dominio.Aliquota;
using Dominio.Operacao;
using System;

namespace Servico.Operacao
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IAliquotaRepository _aliquotaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(IAliquotaRepository aliquotaRepository,
                                ITransacaoRepository transacaoRepository)
        {
            _aliquotaRepository = aliquotaRepository;
            _transacaoRepository = transacaoRepository;
        }

        public void ObterAliquotasParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente)
        {
            foreach (var item in transacao.Transacoes)
            {
                var aliquota = _aliquotaRepository.ObterPorAdquirenteBandeira(idBandeira, idAdquirente);
                item.Aliquota = aliquota;
            }
        }
    }
}
