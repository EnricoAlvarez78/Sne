using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Perfil
    {
        public Perfil()
        {
            Usuario = new List<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public short DiasExpiracaoSenha { get; set; }
        public short QtdErrosSenha { get; set; }
        public bool Ativo { get; set; }
        public int? IdProcedimento { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdLoginInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdLoginAlteracao { get; set; }

        public Procedimento IdProcedimentoNavigation { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
