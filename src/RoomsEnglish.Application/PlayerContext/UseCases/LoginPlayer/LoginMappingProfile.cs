using AutoMapper;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginMappingProfile : Profile
{
    public LoginMappingProfile()
    {
        CreateMap<LoginViewModel, LoginCommand>();
    }
}
