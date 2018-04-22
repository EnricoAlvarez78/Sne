using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class Colesterol
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public int Hdl { get; set; }
        public int Ldl { get; set; }
        public int Vldl { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
