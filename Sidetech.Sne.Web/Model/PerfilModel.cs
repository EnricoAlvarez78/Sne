namespace Sidetech.Sne.Web.Model
{
    public class PerfilModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public short DiasExpiracaoSenha { get; set; }
        public short QtdErrosSenha { get; set; }
        public bool Ativo { get; set; }
  //      public int? IdProcedimento { get; set; }
    }
}
