using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using Sidetech.Sne.Domain.Interfaces.Services;

namespace Sidetech.Sne.DomainService.Services
{
    public class PerfilService : GenericService<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository _repository;

        public PerfilService(IPerfilRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
