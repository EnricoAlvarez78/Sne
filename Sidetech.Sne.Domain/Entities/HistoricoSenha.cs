using System;

namespace Sidetech.Sne.Domain.Entities
{
    public class HistoricoSenha
    {
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Senha { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
