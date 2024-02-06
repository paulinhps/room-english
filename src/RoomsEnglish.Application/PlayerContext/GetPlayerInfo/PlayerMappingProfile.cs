using AutoMapper;

namespace RoomsEnglish.Application.PlayerContext.GetPlayerInfo;

public class PlayerMappingProfile : Profile
{
    public PlayerMappingProfile()
    {
        //CreateMap<PlayerViewModel, GetPlayerByIdQuery>();
        CreateMap<Guid, GetPlayerByIdQuery>()
            .ForMember(x => x.Id, x => x.MapFrom(x => x));
    }
}
