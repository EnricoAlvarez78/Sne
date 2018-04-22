using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class AcuidadeVisual
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public byte Esquerdo { get; set; }
        public byte Direito { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
