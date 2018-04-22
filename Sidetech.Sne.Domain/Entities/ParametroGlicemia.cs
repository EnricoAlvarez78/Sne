using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class ParametroGlicemia
    {
        public int Id { get; set; }
        public short Inicio { get; set; }
        public short Fim { get; set; }
        public bool Jejum { get; set; }
        public string Mensagem { get; set; }
    }
}
