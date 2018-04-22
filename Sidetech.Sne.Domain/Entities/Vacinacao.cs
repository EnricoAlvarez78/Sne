using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class Vacinacao
    {
        public int IdEventoBeneficiario { get; set; }
        public int IdEventoProcedimento { get; set; }
        public int IdVacina { get; set; }
        public DateTime? Fim { get; set; }

        public EventoBeneficiario IdEventoBeneficiarioNavigation { get; set; }
        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
        public Vacina IdVacinaNavigation { get; set; }
    }
}
