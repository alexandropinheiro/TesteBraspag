using System;
using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Dominio.Operacao;
using Dominio.Aliquota;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.AuthenticateUtils;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TransacaoController : Controller
    {
        private readonly ITaxaRepository _taxaRepository;

        public TransacaoController(ITaxaRepository taxaRepository)
        {
            _taxaRepository = taxaRepository;
        }

        [HttpPost]
        [Route("calcularvalores")]
        [Authorize(Policy = "PodeGravarTransacao")]
        public IActionResult CalcularValores([FromBody]DadosTransacaoViewModel dadosTransacaoViewModel)
        {
            try
            {
                var valorTransacao = dadosTransacaoViewModel.ValorCartao;

                var transacaoFactory = new TransacaoFactory(valorTransacao);
                var transacao = transacaoFactory.Criar();

                var taxa = _taxaRepository.ObterPorAdquirenteBandeira(dadosTransacaoViewModel.IdBandeira, dadosTransacaoViewModel.IdAdquirente);

                transacao.CriarItem(taxa,
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
        [Authorize(Policy = "PodeGravarTransacao")]
        public IActionResult CalcularValoresListaCartoes([FromBody]List<DadosTransacaoViewModel> dadosTransacaoViewModel)
        {
            try
            {
                var valorTransacao = dadosTransacaoViewModel.Sum(x => x.ValorCartao);

                var transacaoFactory = new TransacaoFactory(valorTransacao);
                var transacao = transacaoFactory.Criar();

                dadosTransacaoViewModel.ForEach(
                    x =>
                        transacao.CriarItem(_taxaRepository.ObterPorAdquirenteBandeira(x.IdBandeira, x.IdAdquirente),
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