using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Entities
{
    public class Estado
    {
        public Estado()
        {
            Municipio = new List<Municipio>();
        }

        public byte Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public ICollection<Municipio> Municipio { get; set; }
    }
}
