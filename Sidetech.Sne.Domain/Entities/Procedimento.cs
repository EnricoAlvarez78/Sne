using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Procedimento
    {
        public Procedimento()
        {
            EventoProcedimento = new List<EventoProcedimento>();
            Perfil = new List<Perfil>();
            Vacina = new List<Vacina>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte Tempo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }

        public ICollection<EventoProcedimento> EventoProcedimento { get; set; }
        public ICollection<Perfil> Perfil { get; set; }
        public ICollection<Vacina> Vacina { get; set; }
    }
}
