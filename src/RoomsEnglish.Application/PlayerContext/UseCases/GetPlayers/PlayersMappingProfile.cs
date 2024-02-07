using AutoMapper;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;

public class PlayersMappingProfile : Profile
{
    public PlayersMappingProfile()
    {
        CreateMap<Player, PlayerViewModel>();
    }
}
