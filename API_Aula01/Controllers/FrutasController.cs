using Microsoft.AspNetCore.Mvc;

namespace API_Aula01.Controllers
{
    [ApiController]
    public class FrutasController : ControllerBase
    {
        private static readonly string[] Frutas = new[]
        {
            "Uva", "Banana", "Manga", "Caj�", "Pinha", "Lim�o", "Ma��"
        };

        private readonly ILogger<FrutasController> _logger;

        public FrutasController(ILogger<FrutasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("frutas/todas")]
        public IEnumerable<string> GetTodas()
        {
            return Frutas;
        }
    }
}
