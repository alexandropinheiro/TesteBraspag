using System;

namespace Api.ViewModels
{
    public class DadosTransacaoViewModel
    {
        public decimal ValorTransacao { get; set; }

        public Guid IdBandeira { get; set; }
        public Guid IdAdquirente { get; set; }

        public string NumeroCartao { get; set; }
        public string ValidadeCartao { get; set; }
        public string CvvCartao { get; set; }
        public decimal ValorCartao { get; set; }
    }
}
