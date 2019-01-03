using Dominio.Aliquota;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
            RegisterLog.Log(TipoLog.Info, "Obter Bandeiras.");
            return Ok(_bandeiraRepository.ObterTodos());
        }
    }
}