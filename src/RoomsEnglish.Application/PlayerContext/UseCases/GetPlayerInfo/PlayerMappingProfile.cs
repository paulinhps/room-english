using AutoMapper;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;

public class PlayerMappingProfile : Profile
{
    public PlayerMappingProfile()
    {
        CreateMap<Guid, GetPlayerByIdQuery>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
        CreateMap<Player, PlayerViewModel>();
    }
}