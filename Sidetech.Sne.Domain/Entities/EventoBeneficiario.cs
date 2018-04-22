using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class EventoBeneficiario
    {
        public EventoBeneficiario()
        {
            AcuidadeVisual = new List<AcuidadeVisual>();
            Colesterol = new List<Colesterol>();
            Glicemia = new List<Glicemia>();
            Imc = new List<Imc>();
            PressaoArterial = new List<PressaoArterial>();
            TipagemSanguinea = new List<TipagemSanguinea>();
            Vacinacao = new List<Vacinacao>();
        }

        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int IdBeneficiario { get; set; }
        public DateTime Inicio { get; set; }

        public Beneficiario IdBeneficiarioNavigation { get; set; }
        public Evento IdEventoNavigation { get; set; }
        public ICollection<AcuidadeVisual> AcuidadeVisual { get; set; }
        public ICollection<Colesterol> Colesterol { get; set; }
        public ICollection<Glicemia> Glicemia { get; set; }
        public ICollection<Imc> Imc { get; set; }
        public ICollection<PressaoArterial> PressaoArterial { get; set; }
        public ICollection<TipagemSanguinea> TipagemSanguinea { get; set; }
        public ICollection<Vacinacao> Vacinacao { get; set; }
    }
}
