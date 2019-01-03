using System;
using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Dominio.Operacao;
using Dominio.Aliquota;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using log4net;
using System.Reflection;
using Dominio;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TransacaoController : Controller
    {
        private readonly ITaxaRepository _taxaRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IUnitOfWork _uow;
        
        public TransacaoController(ITaxaRepository taxaRepository, 
                                   ITransacaoRepository transacaoRepository,
                                   IUnitOfWork uow)
        {
            _taxaRepository = taxaRepository;
            _transacaoRepository = transacaoRepository;
            _uow = uow;
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

                RegisterLog.Log(TipoLog.Info, "Consulta para Obter Taxa por Bandeira e Adquirente");
                var taxa = _taxaRepository.ObterPorAdquirenteBandeira(dadosTransacaoViewModel.IdBandeira, dadosTransacaoViewModel.IdAdquirente);

                if (taxa == null)
                    throw new Exception("Taxa não encontrada");

                transacao.CriarItem(taxa,
                                    dadosTransacaoViewModel.NumeroCartao,
                                    dadosTransacaoViewModel.ValidadeCartao,
                                    dadosTransacaoViewModel.CvvCartao,
                                    dadosTransacaoViewModel.ValorCartao);

                RegisterLog.Log(TipoLog.Info, "Gravação da Transação.");

                _transacaoRepository.Gravar(transacao);
                _uow.Commit();

                var itemTransacao = transacao.Transacoes.FirstOrDefault();

                RegisterLog.Log(TipoLog.Info, "Sucesso ao calcular valores.");
                return Ok(itemTransacao.DescricaoRetorno);

            }
            catch (Exception e)
            {
                RegisterLog.Log(TipoLog.Error, "Erro na execução do cálculo de valores");
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

                RegisterLog.Log(TipoLog.Info, "Criar item de transacao para cada informação de cartão da lista.");

                dadosTransacaoViewModel.ForEach(
                    x => {
                        var taxa = _taxaRepository.ObterPorAdquirenteBandeira(x.IdBandeira, x.IdAdquirente);

                        if (taxa == null)
                            throw new Exception("Taxa não encontrada.");

                        transacao.CriarItem(taxa,
                                            x.NumeroCartao,
                                            x.ValidadeCartao,
                                            x.CvvCartao,
                                            x.ValorCartao);
                    }
                );

                RegisterLog.Log(TipoLog.Info, "Gravação da Transação.");
                _transacaoRepository.Gravar(transacao);
                _uow.Commit();

                var retorno = new List<string>();

                foreach (var item in transacao.Transacoes)
                    retorno.Add(item.DescricaoRetorno);

                RegisterLog.Log(TipoLog.Info, "Sucesso ao calcular valores para mais de um cartão.");
                return Ok(retorno);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}