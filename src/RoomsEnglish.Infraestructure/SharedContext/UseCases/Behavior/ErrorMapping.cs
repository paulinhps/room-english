using AutoMapper;
using FluentValidation.Results;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class ErrorMapping : Profile
{
    public ErrorMapping()
    {
        CreateMap<ValidationFailure, Error>()
        .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.PropertyName))
        .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.ErrorMessage));
    }
}