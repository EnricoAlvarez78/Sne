using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            HistoricoSenha = new List<HistoricoSenha>();
        }

        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public int IdUsuarioAlteracao { get; set; }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string FormatoEmail { get; set; }

        public bool Ativo { get; set; }
        public bool Bloqueado { get; set; }
        public bool PrimeiroAcesso { get; set; }

        public DateTime? DataNascimento { get; set; }
        public DateTime? DataUltimoAcesso { get; set; } 

        public DateTime DataExpiracaoSenha { get; set; } 
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

        public Perfil IdPerfilNavigation { get; set; }
        public ICollection<HistoricoSenha> HistoricoSenha { get; set; }
    }
}
