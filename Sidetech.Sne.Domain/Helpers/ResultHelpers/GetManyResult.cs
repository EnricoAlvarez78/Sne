using System.Collections.Generic;

namespace Sidetech.Sne.Domain.Helpers.ResultHelpers
{
    public class GetManyResult<TEntity> : OperationResult where TEntity : class
    {
        public long TotalAmount { get; set; } = 0;

        public IEnumerable<TEntity> Entities { get; set; } = null;
    }
}
