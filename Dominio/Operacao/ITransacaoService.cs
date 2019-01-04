using System;

namespace Dominio.Operacao
{
    public interface ITransacaoService
    {
        void ObterTaxaParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente);
    }
}
