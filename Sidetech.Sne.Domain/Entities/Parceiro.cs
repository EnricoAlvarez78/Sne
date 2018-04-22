using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Parceiro
    {
        public Parceiro()
        {
            EventoParceiro = new List<EventoParceiroDao>();
            Participante = new List<Participante>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public bool InstituicaoEnsino { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public int? Telefone { get; set; }
        public byte? Ddd { get; set; }
        public string Observacao { get; set; }

        public ICollection<EventoParceiroDao> EventoParceiro { get; set; }
        public ICollection<Participante> Participante { get; set; }
    }
}
