using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Operacao
{
    public interface ITransacaoService
    {
        void ObterAliquotasParaAsTransacoes(Transacao transacao, Guid idBandeira, Guid idAdquirente);
    }
}
