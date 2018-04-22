namespace Sidetech.Sne.Domain.Helpers.ResultHelpers
{
    public class GetOneResult<TEntity> : OperationResult where TEntity : class
    {
        public TEntity Entity { get; set; }
    }
}
