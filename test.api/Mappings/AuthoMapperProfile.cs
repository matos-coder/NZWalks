using AutoMapper;
using test.api.models.domain;
using test.api.models.DTOs;

namespace test.api.Mappings
{
    public class AuthoMapperProfile: Profile
    {
        public AuthoMapperProfile()
        {
            CreateMap<region, regionsdto>().ReverseMap();
            CreateMap<addRegionDto, region>().ReverseMap();
            CreateMap<putRegionDto, region>().ReverseMap();
        }
    }
}
