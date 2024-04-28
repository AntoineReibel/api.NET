using apindien2.Models;
using apindien2.Models.DTO;
using AutoMapper;

namespace apindien2
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();
            CreateMap<Villa, VillaDTOCreate>().ReverseMap();
            CreateMap<Villa, VillaDTOUpdate>().ReverseMap();
        }
    }
}
