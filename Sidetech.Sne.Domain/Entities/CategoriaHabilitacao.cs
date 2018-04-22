using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class CategoriaHabilitacao
    {
        public CategoriaHabilitacao()
        {
            Beneficiario = new List<Beneficiario>();
        }

        public int Id { get; set; }
        public string SiglaCategoria { get; set; }
        public string Descricao { get; set; }

        public ICollection<Beneficiario> Beneficiario { get; set; }
    }
}
