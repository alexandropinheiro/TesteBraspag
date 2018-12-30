using Dominio.Base;
using Dominio.Aliquota;
using System;
using System.Collections.Generic;

namespace Dominio.Operacao
{
    public class Transacao : EntidadeBase
    {
        public Transacao()
        {
            Data = DateTime.Now;
            Transacoes = new List<ItemTransacao>();
        }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public ICollection<ItemTransacao> Transacoes { get; set; }

        public void CriarItem(Taxa taxa, string numeroCartao, string validade, string cvv, decimal valor)
        {
            Transacoes.Add(new ItemTransacao
            {
                Id = Guid.NewGuid(),
                IdTaxa = taxa.Id,
                Taxa = taxa,
                NumeroCartao = numeroCartao,
                Validade = validade,
                Cvv = cvv,
                Valor = valor,
                IdTransacao = Id
            });
        }
    }
}
