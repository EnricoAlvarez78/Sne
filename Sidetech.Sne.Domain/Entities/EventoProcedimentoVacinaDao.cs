namespace Sidetech.Sne.Domain.Entities
{
    public class EventoProcedimentoVacinaDao
    {
        public int IdEventoProcedimento { get; set; }
        public int IdVacina { get; set; }

        public EventoProcedimento IdEventoProcedimentoNavigation { get; set; }
        public Vacina IdVacinaNavigation { get; set; }
    }
}
