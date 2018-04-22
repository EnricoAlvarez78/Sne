using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class EventoProcedimento
    {
        public EventoProcedimento()
        {
            AcuidadeVisual = new List<AcuidadeVisual>();
            Colesterol = new List<Colesterol>();
            EventoProcedimentoVacina = new List<EventoProcedimentoVacinaDao>();
            Glicemia = new List<Glicemia>();
            Imc = new List<Imc>();
            PressaoArterial = new List<PressaoArterial>();
            TipagemSanguinea = new List<TipagemSanguinea>();
            Vacinacao = new List<Vacinacao>();
        }

        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int IdProcedimento { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Procedimento IdProcedimentoNavigation { get; set; }
        public ICollection<AcuidadeVisual> AcuidadeVisual { get; set; }
        public ICollection<Colesterol> Colesterol { get; set; }
        public ICollection<EventoProcedimentoVacinaDao> EventoProcedimentoVacina { get; set; }
        public ICollection<Glicemia> Glicemia { get; set; }
        public ICollection<Imc> Imc { get; set; }
        public ICollection<PressaoArterial> PressaoArterial { get; set; }
        public ICollection<TipagemSanguinea> TipagemSanguinea { get; set; }
        public ICollection<Vacinacao> Vacinacao { get; set; }
    }
}
