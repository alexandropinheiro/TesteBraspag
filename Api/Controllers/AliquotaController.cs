using Api.ViewModel;
using Dominio;
using Dominio.Aliquota;
using Microsoft.AspNetCore.Mvc;

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
            var aliquota = _aliquotaRepository.ObterPorId(aliquotaViewModel.Id);
            aliquota.Percentual = aliquotaViewModel.Taxa;

            _aliquotaRepository.Atualizar(aliquota);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}