using System;
using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Dominio.Operacao;
using Dominio.Aliquota;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITaxaRepository _aliquotaRepository;

        public TransacaoController(ITaxaRepository aliquotaRepository)
        {
            _aliquotaRepository = aliquotaRepository;
        }

        [HttpPost]
        [Route("CalcularValores")]
        public IActionResult CalcularValores([FromBody]DadosTransacaoViewModel dadosTransacaoViewModel)
        {
            try
            {
                var transacaoFactory = new TransacaoFactory(dadosTransacaoViewModel.ValorTransacao);
                var transacao = transacaoFactory.Criar();

                var aliquota = _aliquotaRepository.ObterPorAdquirenteBandeira(dadosTransacaoViewModel.IdBandeira, dadosTransacaoViewModel.IdAdquirente);

                transacao.CriarItem(aliquota,
                                    dadosTransacaoViewModel.NumeroCartao,
                                    dadosTransacaoViewModel.ValidadeCartao,
                                    dadosTransacaoViewModel.CvvCartao,
                                    dadosTransacaoViewModel.ValorCartao);

                var itemTransacao = transacao.Transacoes.FirstOrDefault();

                return Ok(itemTransacao.DescricaoRetorno);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CalcularValoresListaCartoes")]
        public IActionResult CalcularValoresListaCartoes([FromBody]List<DadosTransacaoViewModel> dadosTransacaoViewModel)
        {
            try
            {
                var valorTransacao = dadosTransacaoViewModel.Sum(x => x.ValorCartao);

                var transacaoFactory = new TransacaoFactory(valorTransacao);
                var transacao = transacaoFactory.Criar();

                dadosTransacaoViewModel.ForEach(
                    x =>
                        transacao.CriarItem(_aliquotaRepository.ObterPorAdquirenteBandeira(x.IdBandeira, x.IdAdquirente),
                                            x.NumeroCartao,
                                            x.ValidadeCartao,
                                            x.CvvCartao,
                                            x.ValorCartao)
                );

                var retorno = new List<string>();

                foreach (var item in transacao.Transacoes)
                    retorno.Add(item.DescricaoRetorno);

                return Ok(retorno);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}