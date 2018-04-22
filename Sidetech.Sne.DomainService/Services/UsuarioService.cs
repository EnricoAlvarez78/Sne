using System.Threading.Tasks;
using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Domain.Helpers.ResultHelpers;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using Sidetech.Sne.Domain.Interfaces.Services;

namespace Sidetech.Sne.DomainService.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override Task<GetOneResult<Usuario>> Add(Usuario obj)
        {
            // todo: provisório até criar a camada de controle de acesso
            obj.Senha = "SenhaFake";
            return base.Add(obj);
        }

        public override Task<OperationResult> Update(Usuario obj)
        {
            // todo: provisório até criar a camada de controle de acesso
            obj.Senha = "SenhaFake";
            return base.Update(obj);
        }
    }
}
