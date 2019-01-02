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

        public double Valor { get; set; }

        public Transacao Transacao { get; set; }
        public Taxa Taxa { get; set; }

        public double ValorAdquirente
        {
            get
            {
                return Math.Round(Valor * Taxa.Percentual, 2);
            }   
        }

        public double ValorLojista
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
