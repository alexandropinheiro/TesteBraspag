using Dominio.Adquirentes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AdquirenteController : Controller
    {
        private readonly IAdquirenteRepository _adquirenteRepository;
        
        public AdquirenteController(IAdquirenteRepository adquirenteRepository)
        {
            _adquirenteRepository = adquirenteRepository;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarAdquirentes()
        {
            RegisterLog.Log(TipoLog.Info, "Obter Adquirentes.");

            return Ok(_adquirenteRepository.ObterTodos());
        }
    }
}