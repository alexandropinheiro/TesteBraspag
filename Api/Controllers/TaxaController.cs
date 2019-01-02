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
        private readonly ITaxaRepository _aliquotaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaxaController(ITaxaRepository aliquotaRepository, IUnitOfWork unitOfWork)
        {
            _aliquotaRepository = aliquotaRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        [Route("atualizar")]
        [Authorize(Roles = Roles.ROLE_SUPERVISOR)]
        public IActionResult AtualizarAliquota([FromBody]TaxaViewModel aliquotaViewModel)
        {
            try
            {
                var aliquota = _aliquotaRepository.ObterPorId(aliquotaViewModel.Id);
                aliquota.Percentual = aliquotaViewModel.Taxa;
                
                _aliquotaRepository.Atualizar(aliquota);
                _unitOfWork.Commit();

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Atualização realizada com sucesso!");
        }
    }
}