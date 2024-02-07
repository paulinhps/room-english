using AutoMapper;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;

public class PlayerMappingProfile : Profile
{
    public PlayerMappingProfile()
    {
        CreateMap<Guid, GetPlayerByIdQuery>()
            .ForMember(x => x.Id, x => x.MapFrom(x => x));
        CreateMap<Player, PlayerViewModel>();
    }
}