using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Operacao
{
    public interface ITransacaoService
    {
        void ObterTaxaParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente);
    }
}
