using System;

namespace Api.ViewModels
{
    public class DadosTransacaoViewModel
    {
        public Guid IdBandeira { get; set; }
        public Guid IdAdquirente { get; set; }

        public string NumeroCartao { get; set; }
        public string ValidadeCartao { get; set; }
        public string CvvCartao { get; set; }
        public double ValorCartao { get; set; }
    }
}
