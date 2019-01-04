using Api.ViewModel;
using Dominio;
using Dominio.Taxas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TaxaController : Controller
    {
        private readonly ITaxaRepository _taxaRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public TaxaController(ITaxaRepository taxaRepository, IUnitOfWork unitOfWork)
        {
            _taxaRepository = taxaRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        [Route("atualizar/{id:guid}")]
        [Authorize(Policy = "PodeAlterarTaxa")]
        public IActionResult AtualizarTaxa(Guid id, [FromBody]TaxaViewModel taxaViewModel)
        {
            try
            {
                var taxa = _taxaRepository.ObterPorId(id);

                if (taxa == null)
                    throw new Exception("Taxa não encontrada.");

                taxa.Percentual = taxaViewModel.Taxa;

                RegisterLog.Log(TipoLog.Info, "Atualização de percentual da taxa.");

                _taxaRepository.Atualizar(taxa);
                _unitOfWork.Commit();

            }catch(Exception e)
            {
                RegisterLog.Log(TipoLog.Error, "Erro ao atualizar taxa.");
                return BadRequest(e.Message);
            }

            RegisterLog.Log(TipoLog.Info, "Atualização realizada com sucesso!");

            return Ok("Atualização realizada com sucesso!");
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarTaxas()
        {
            RegisterLog.Log(TipoLog.Info, "Obter Taxas");
            return Ok(_taxaRepository.ObterTodos());
        }
    }
}