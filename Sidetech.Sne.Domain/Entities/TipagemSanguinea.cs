using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class TipagemSanguinea
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
    }
}
