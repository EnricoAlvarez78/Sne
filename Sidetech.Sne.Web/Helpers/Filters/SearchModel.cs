using Sidetech.Sne.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sidetech.Sne.Web.Helpers.Filters
{
    public class SearchModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "O valor do indice da página deve ser entre {1} e {2}")]
        public int? PageIndex { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "O valor da quantidade de items por página deve ser entre {1} e {2}")]
        public int? PageSize { get; set; } = 0;

        public string SortField { get; set; }

        public SortDirect SortDirection { get; set; }

        public Dictionary<string, string> Filters { get; set; } = new Dictionary<string, string>();
    }
}
