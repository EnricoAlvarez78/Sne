using System;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Beneficiario = new List<Beneficiario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }

        public ICollection<Beneficiario> Beneficiario { get; set; }
    }
}
