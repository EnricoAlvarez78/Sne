namespace Sidetech.Sne.Domain.Entities
{
    public class ParametroPressaoArterial
    {
        public int Id { get; set; }
        public byte InicioMaxima { get; set; }
        public byte FimMaxima { get; set; }
        public byte InicioMinima { get; set; }
        public byte FimMinima { get; set; }
        public string Mensagem { get; set; }
        public byte Ordem { get; set; }
    }
}
