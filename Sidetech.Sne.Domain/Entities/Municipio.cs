using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class Municipio
    {
        public Municipio()
        {
            Beneficiario = new List<Beneficiario>();
            Empregador = new List<Empregador>();
            Evento = new List<Evento>();
        }

        public int Id { get; set; }
        public byte IdEstado { get; set; }
        public string Nome { get; set; }

        public Estado IdEstadoNavigation { get; set; }
        public ICollection<Beneficiario> Beneficiario { get; set; }
        public ICollection<Empregador> Empregador { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
