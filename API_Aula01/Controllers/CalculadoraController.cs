using Microsoft.AspNetCore.Mvc;
using API_Aula01.Models; 

namespace API_Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private static readonly Operacao[] OperacoesDisponiveis = new Operacao[]
        {
            new Operacao { Nome = "Soma", Sigla = "SUM", Valor = "+" },
            new Operacao { Nome = "Subtração", Sigla = "SUB", Valor = "-" },
            new Operacao { Nome = "Multiplicação", Sigla = "MULT", Valor = "*" },
            new Operacao { Nome = "Divisão", Sigla = "DIV", Valor = "/" }
        };

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("operacoes")]
        public IEnumerable<Operacao> GetOperacoes()
        {
            _logger.LogInformation("Endpoint calculadora/operacoes acessado para retornar todas as operações.");
            
            return OperacoesDisponiveis;
        }
        [HttpPost]
        [Route("calcular")]
        public ActionResult<OperacaoResponse> Calcular([FromBody] OperacaoRequest request)
        {
            _logger.LogInformation("Endpoint calculadora/calcular acessado para calcular a operação.");
            if (request == null)
            {
                return BadRequest(new { message = "Dados de entrada são obrugatórios." });
            }
            double resultado;

            switch (request.Operacao)
            {
                case "+":
                    resultado = request.PrimeiroNumero + request.SegundoNumero;
                    break;
                case "-":
                    resultado = request.PrimeiroNumero - request.SegundoNumero;
                    break;
                case "*":
                    resultado = request.PrimeiroNumero * request.SegundoNumero;
                    break;
                case "/":
                    if (request.SegundoNumero == 0)
                    {
                        return BadRequest(new { message = "Divisão por zero não é permitida." });
                    }
                    resultado = request.PrimeiroNumero / request.SegundoNumero;
                    break;
                default:
                    return BadRequest(new { message = "Operação inválida." });
                }
                return Ok(new OperacaoResponse { Resultado = resultado });
        }
    }
}