using Microsoft.AspNetCore.Mvc;
using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Domain.Interfaces.Services;
using Sidetech.Sne.Web.Model;

namespace Sidetech.Sne.Web.Controllers.V1
{
    [ApiVersion("1")]
    public class UsuarioController : GenericController<Usuario, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
    }
}
