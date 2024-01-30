using AutoMapper;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;

public class PlayerMappingProfile : Profile
{
    public PlayerMappingProfile()
    {
        //CreateMap<PlayerViewModel, GetPlayerByIdQuery>();
        CreateMap<Guid, GetPlayerByIdQuery>()
            .ForMember(x => x.Id, x => x.MapFrom(x => x));
    }
}
