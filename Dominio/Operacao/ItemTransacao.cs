using Dominio.Base;
using Dominio.Aliquota;
using System;

namespace Dominio.Operacao
{
    public class ItemTransacao : EntidadeBase
    {
        public Guid IdTransacao { get; set; }        
        public Guid IdTaxa { get; set; }

        public string NumeroCartao { get; set; }
        public string Validade { get; set; }
        public string Cvv { get; set; }

        public decimal Valor { get; set; }

        public Transacao Transacao { get; set; }
        public Taxa Taxa { get; set; }

        public decimal ValorAdquirente
        {
            get
            {
                return Math.Round(Convert.ToDecimal(Valor * Taxa.Percentual), 2);
            }   
        }

        public decimal ValorLojista
        {
            get
            {
                return Valor - ValorAdquirente;
            }
        }

        public string DescricaoRetorno
        {
            get
            {
                return $"Cartão: {NumeroCartao}; Valor Lojista: R${ValorLojista.ToString("#,###.00")}; Valor Adquirente: R${ValorAdquirente.ToString("#,###.00")}.";
            }
        }
    }
}
