using AutoMapper;

namespace RoomsEnglish.Application.AccountContext.LoginIn;

public class AuthUserCommandMappingProfile: Profile
{
    public AuthUserCommandMappingProfile()
    {
        CreateMap<LoginViewModel, AuthUserCommand>();
    }
}
