using Api.ViewModel;
using Dominio;
using Dominio.Aliquota;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AliquotaController : Controller
    {
        private readonly IAliquotaRepository _aliquotaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AliquotaController(IAliquotaRepository aliquotaRepository, IUnitOfWork unitOfWork)
        {
            _aliquotaRepository = aliquotaRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarAliquota([FromBody]AliquotaViewModel aliquotaViewModel)
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