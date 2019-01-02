using Api.AuthenticateUtils;
using Api.ViewModel;
using Dominio;
using Dominio.Aliquota;
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
        [Route("atualizar")]
        [Authorize(Policy = "PodeAlterarTaxa")]
        public IActionResult AtualizarTaxa([FromBody]TaxaViewModel taxaViewModel)
        {
            try
            {
                var taxa = _taxaRepository.ObterPorId(taxaViewModel.Id);
                taxa.Percentual = taxaViewModel.Taxa;
                
                _taxaRepository.Atualizar(taxa);
                _unitOfWork.Commit();

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Atualização realizada com sucesso!");
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarTaxas()
        {
            return Ok(_taxaRepository.ObterTodos());
        }
    }
}