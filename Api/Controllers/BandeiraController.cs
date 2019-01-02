using Dominio.Aliquota;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BandeiraController : Controller
    {
        private readonly IBandeiraRepository _bandeiraRepository;

        public BandeiraController(IBandeiraRepository bandeiraRepository)
        {
            _bandeiraRepository = bandeiraRepository;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarBandeiras()
        {
            return Ok(_bandeiraRepository.ObterTodos());
        }
    }
}