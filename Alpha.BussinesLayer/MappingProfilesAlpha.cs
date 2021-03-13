using Alpha.BussinesLayer.Dto;
using Alpha.DataAccesLayer.Entities;
using AutoMapper;


namespace Alpha.BussinesLayer
{
    public class MappingProfilesAlpha : Profile
    {
        public MappingProfilesAlpha() 
        {
            CreateMap<CorrespondenciaResponseDto, Correspondencia>().ReverseMap();
            CreateMap<CorrespondenciaRequestDto, Correspondencia>();
            CreateMap<UsuarioResponseDto, Usuario>().ReverseMap();
        }
    }
}
