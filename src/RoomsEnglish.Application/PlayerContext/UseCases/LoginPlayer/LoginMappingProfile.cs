using AutoMapper;
using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginPlayerMapping : Profile
{
    public LoginPlayerMapping()
    {
        CreateMap<LoginViewModel, LoginCommand>();

        CreateMap<IApplicationUser, LoginResult>()
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.AuthToken, opt => opt.Ignore());

    }
}
