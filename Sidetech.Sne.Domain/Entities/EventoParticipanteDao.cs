namespace Sidetech.Sne.Domain.Entities
{
    public class EventoParticipanteDao
    {
        public int IdEvento { get; set; }
        public int IdParticipante { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Participante IdParticipanteNavigation { get; set; }
    }
}
