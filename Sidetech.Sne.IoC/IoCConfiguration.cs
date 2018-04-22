using Microsoft.Extensions.DependencyInjection;
using Sidetech.Sne.Data.Repositories;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using Sidetech.Sne.Domain.Interfaces.Services;
using Sidetech.Sne.DomainService.Services;

namespace Sidetech.Sne.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            // Domain
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(IPerfilService), typeof(PerfilService));
            services.AddScoped(typeof(ICategoriaService), typeof(CategoriaService));

            // Data
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IPerfilRepository), typeof(PerfilRepository));
            services.AddScoped(typeof(ICategoriaRepository),typeof(CategoriaRepository));
        }
    }
}
