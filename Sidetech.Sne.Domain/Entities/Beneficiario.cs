using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Beneficiario
    {
        public Beneficiario()
        {
            EventoBeneficiario = new List<EventoBeneficiario>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int? IdMunicipio { get; set; }
        public byte? Ddd { get; set; }
        public int? Telefone { get; set; }
        public int IdCategoria { get; set; }
        public int? IdEmpregador { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public int? IdEscolaridade { get; set; }
        public string Email { get; set; }
        public int? IdHabilitacao { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Empregador IdEmpregadorNavigation { get; set; }
        public Escolaridade IdEscolaridadeNavigation { get; set; }
        public CategoriaHabilitacao IdHabilitacaoNavigation { get; set; }
        public Municipio IdMunicipioNavigation { get; set; }
        public ICollection<EventoBeneficiario> EventoBeneficiario { get; set; }
    }
}
