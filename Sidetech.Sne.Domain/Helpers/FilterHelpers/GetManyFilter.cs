using Sidetech.Sne.Domain.Enums;
using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Helpers.FilterHelpers
{
    public class GetManyFilter<TEntity> where TEntity : class
    {
        public Dictionary<string, string> Filters { get; set; } = new Dictionary<string, string>();

        public Dictionary<SortDirect, string> Sort { get; set; } = new Dictionary<SortDirect, string>();
    }
}
