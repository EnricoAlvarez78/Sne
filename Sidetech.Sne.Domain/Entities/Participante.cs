using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Participante
    {
        public Participante()
        {
            EventoParticipante = new List<EventoParticipanteDao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte? Carga1 { get; set; }
        public int IdParceiro { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public byte? Carga2 { get; set; }

        public Parceiro IdParceiroNavigation { get; set; }
        public ICollection<EventoParticipanteDao> EventoParticipante { get; set; }
    }
}
