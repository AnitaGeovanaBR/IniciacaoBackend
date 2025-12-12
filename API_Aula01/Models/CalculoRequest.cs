namespace API_Aula01.Models
{
    public class CalculoRequest
    {
        public double PrimeiroNumero { get; set; }
        public double SegundoNumero { get; set; }
        public string Operacao { get; set; } = string.Empty;
    }
}