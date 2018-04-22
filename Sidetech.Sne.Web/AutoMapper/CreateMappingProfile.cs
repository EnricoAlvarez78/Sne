using AutoMapper;
using Sidetech.Sne.Domain.Entities;
using Sidetech.Sne.Web.Model;

namespace Sidetech.Sne.Web.AutoMapper
{
    public class CreateMappingProfile : Profile
    {
        public CreateMappingProfile()
        {
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<Perfil, PerfilModel>().ReverseMap();

            CreateMap<Categoria, CategoriaModel>().ReverseMap();
        }
    }
}
