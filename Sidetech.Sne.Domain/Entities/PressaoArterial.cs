using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class PressaoArterial
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public short PressaoMaxima { get; set; }
        public short PressaoMinima { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
