using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Vacina
    {
        public Vacina()
        {
            EventoProcedimentoVacina = new List<EventoProcedimentoVacinaDao>();
            Vacinacao = new List<Vacinacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdProcedimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }

        public Procedimento IdProcedimentoNavigation { get; set; }
        public ICollection<EventoProcedimentoVacinaDao> EventoProcedimentoVacina { get; set; }
        public ICollection<Vacinacao> Vacinacao { get; set; }
    }
}
