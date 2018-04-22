using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class ParametroGorduraAbdominal
    {
        public int Id { get; set; }
        public byte Inicio { get; set; }
        public byte Fim { get; set; }
        public string Sexo { get; set; }
        public string Mensagem { get; set; }
    }
}
