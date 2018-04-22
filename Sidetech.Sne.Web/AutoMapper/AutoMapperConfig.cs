using AutoMapper;

namespace Sidetech.Sne.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CreateMappingProfile>();
            });
        }
    }
}
