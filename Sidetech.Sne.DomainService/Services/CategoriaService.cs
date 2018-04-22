using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using Sidetech.Sne.Domain.Interfaces.Services;

namespace Sidetech.Sne.DomainService.Services
{
    public class CategoriaService : GenericService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        //public void test()
        //{
        //    var tes = new GetManyFilter<Categoria>
        //    {
        //        Filters = c => c.Ativo.Equals(true)
        //    };

        //    _repository.Count(tes);
        //}
    }
}
