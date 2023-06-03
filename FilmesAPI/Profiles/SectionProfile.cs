using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class SectionProfile : Profile
{
    public SectionProfile()
    {
        CreateMap<CreateSectionDto, Section>();
        CreateMap<Section, ReadSectionDto>();
    }
}
