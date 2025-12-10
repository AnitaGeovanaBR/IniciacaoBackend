using Microsoft.AspNetCore.Mvc;
using API_Aula01.Models; 

namespace API_Aula01.Controllers
{
    [ApiController]
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
        [Route("calculadora/operacoes")]
        public IEnumerable<Operacao> GetOperacoes()
        {
            _logger.LogInformation("Endpoint calculadora/operacoes acessado para retornar todas as operações.");
            
            return OperacoesDisponiveis;
        }
    }
}