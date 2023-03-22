using AutoMapper;
using DrillCRUD.Models;

namespace DrillCRUD.MappingProfiles
{
    public class StandardMappingProfile : Profile
    {
        public StandardMappingProfile()
        {
            CreateMap<HolePoint, HolePointDTO>().ReverseMap();
            CreateMap<DrillBlockPoint, DrillBlockPointDTO>().ReverseMap();
            CreateMap<DrillBlock, DrillBlockDTO>().ReverseMap();
            CreateMap<Hole, HoleDTO>().ReverseMap();

            CreateMap<DrillBlock, DrillBlockFullDTO>();
            CreateMap<Hole, HoleFullDTO>();
        }
    }
}
