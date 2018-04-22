using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class Imc
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public decimal Peso { get; set; }
        public byte Altura { get; set; }
        public decimal Imc1 { get; set; }
        public DateTime? Fim { get; set; }
        public decimal? TotalAguaCorporal { get; set; }
        public decimal? TaxaMetabolismoBasal { get; set; }
        public decimal? GrauObesidadeAbdominal { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
