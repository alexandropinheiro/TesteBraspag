using Dominio.Base;
using System;
using System.Collections.Generic;
using Dominio.Taxas;

namespace Dominio.Operacao
{
    public class Transacao : EntidadeBase
    {
        public Transacao()
        {
            Data = DateTime.Now;
            Transacoes = new List<ItemTransacao>();
        }

        public double Valor { get; set; }
        public DateTime Data { get; set; }

        public ICollection<ItemTransacao> Transacoes { get; set; }

        public void CriarItem(Taxa taxa, string numeroCartao, string validade, string cvv, double valor)
        {
            var itemTransacao = new ItemTransacao
            {
                Id = Guid.NewGuid(),
                IdTaxa = taxa.Id,
                Taxa = taxa,
                NumeroCartao = numeroCartao,
                Validade = validade,
                Cvv = cvv,
                Valor = valor,
                IdTransacao = Id
            };

            itemTransacao.RatearValores();

            Transacoes.Add(itemTransacao);
        }
    }
}
