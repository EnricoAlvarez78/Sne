using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Evento
    {
        public Evento()
        {
            EventoBeneficiario = new List<EventoBeneficiario>();
            EventoParceiro = new List<EventoParceiroDao>();
            EventoParticipante = new List<EventoParticipanteDao>();
            EventoProcedimento = new List<EventoProcedimento>();
        }

        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public int IdMunicipio { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public string Cnpj { get; set; }
        public bool Cancelado { get; set; }

        public Municipio IdMunicipioNavigation { get; set; }
        public ICollection<EventoBeneficiario> EventoBeneficiario { get; set; }
        public ICollection<EventoParceiroDao> EventoParceiro { get; set; }
        public ICollection<EventoParticipanteDao> EventoParticipante { get; set; }
        public ICollection<EventoProcedimento> EventoProcedimento { get; set; }
    }
}
