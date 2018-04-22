using Microsoft.AspNetCore.Mvc;
using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Domain.Interfaces.Services;
using Sidetech.Sne.Web.Model;

namespace Sidetech.Sne.Web.Controllers.V1
{
    [ApiVersion("1")]
    public class PerfilController : GenericController<Perfil, PerfilModel>
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService) : base(perfilService)
        {
            _perfilService = perfilService;
        }
    }
}