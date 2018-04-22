namespace Sidetech.Sne.Domain.Entities
{
    public class EventoParceiroDao
    {
        public int IdEvento { get; set; }
        public int IdParceiro { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Parceiro IdParceiroNavigation { get; set; }
    }
}
