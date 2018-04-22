using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class Glicemia
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public short Glicemia1 { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
