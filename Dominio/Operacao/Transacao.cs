using Dominio.Base;
using Dominio.Aliquota;
using System;
using System.Collections.Generic;

namespace Dominio.Operacao
{
    public class Transacao : EntidadeBase
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public ICollection<ItemTransacao> Transacoes { get; set; }

        public void CriarItem(Taxa aliquota, string numeroCartao, DateTime validade, string cvv, decimal valor)
        {
            Transacoes.Add(new ItemTransacao
            {
                Id = Guid.NewGuid(),
                IdAliquota = aliquota.Id,
                Aliquota = aliquota,
                NumeroCartao = numeroCartao,
                Validade = validade,
                Cvv = cvv,
                Valor = valor,
                IdTransacao = Id
            });
        }
    }
}
