using System;

namespace Sidetech.Sne.Web.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
       // public string Senha { get; set; }
        public int IdPerfil { get; set; }
        public string Email { get; set; }
        public string FormatoEmail { get; set; }
        public bool Ativo { get; set; }
        public bool Bloqueado { get; set; }
        public bool PrimeiroAcesso { get; set; }

        public DateTime? DataNascimento { get; set; }

        public DateTime DataExpiracaoSenha { get; set; } = DateTime.Now.AddYears(1);

        //public Perfil IdPerfilNavigation { get; set; }
        //public ICollection<HistoricoSenha> HistoricoSenha { get; set; }
    }
}
