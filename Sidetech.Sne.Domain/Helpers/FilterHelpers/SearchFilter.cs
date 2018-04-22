namespace Sidetech.Sne.Domain.Helpers.FilterHelpers
{
    public class SearchFilter<TEntity> : GetManyFilter<TEntity> where TEntity : class
    {
        public int? PageIndex { get; set; } = 0;

        public int? PageSize { get; set; } = 0;
    }
}
