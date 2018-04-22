namespace Sidetech.Sne.Domain.Helpers.ResultHelpers
{
    public class GetCountResult<TEntity> : OperationResult where TEntity : class
    {
        public long? Amount { get; set; }
    }
}
