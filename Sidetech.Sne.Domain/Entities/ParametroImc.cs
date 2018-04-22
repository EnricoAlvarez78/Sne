using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class ParametroImc
    {
        public int Id { get; set; }
        public double Inicio { get; set; }
        public double Fim { get; set; }
        public string Mensagem { get; set; }
    }
}
