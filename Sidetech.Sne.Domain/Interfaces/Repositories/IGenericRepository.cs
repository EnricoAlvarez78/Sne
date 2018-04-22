using Sidetech.Sne.Domain.Helpers.FilterHelpers;
using Sidetech.Sne.Domain.Helpers.ResultHelpers;
using System.Threading.Tasks;

namespace Sidetech.Sne.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<GetOneResult<TEntity>> GetById(int id);

        Task<GetManyResult<TEntity>> GetMany(SearchFilter<TEntity> filter);

        Task<GetCountResult<TEntity>> Count(GetManyFilter<TEntity> filter);

        Task<GetOneResult<TEntity>> Add(TEntity obj);

        Task<OperationResult> Update(TEntity obj);

        Task<OperationResult> Remove(TEntity obj);
    }
}
