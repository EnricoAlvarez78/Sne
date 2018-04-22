using System;
using System.Collections.Generic;
using System.Text;

namespace Sidetech.Sne.Domain.Entities
{
    public class LogImportacaoBalanca
    {
        public int Id { get; set; }
        public DateTime DataGeracao { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeLog { get; set; }
    }
}
