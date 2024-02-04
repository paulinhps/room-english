using AutoMapper;

using RoomsEnglish.Application.PlayerContext.ViewModels;

using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.GetPlayers;

public class PlayersMappingProfile : Profile
{
    public PlayersMappingProfile()
    {
        CreateMap<IEnumerable<Player>, IEnumerable<PlayerViewModel>>()
            .ReverseMap();
    }
}
