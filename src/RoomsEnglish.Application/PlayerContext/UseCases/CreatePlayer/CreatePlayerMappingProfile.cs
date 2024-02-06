using AutoMapper;

using RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;
using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class CreatePlayerMappingProfile : Profile
{
    public CreatePlayerMappingProfile()
    {
        CreateMap<CreatePlayerViewModel, CreatePlayerCommand>();
        CreateMap<Player, PlayerInfo>()
        .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Id));
    }
}