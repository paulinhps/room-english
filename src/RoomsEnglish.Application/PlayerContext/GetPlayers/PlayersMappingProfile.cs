using AutoMapper;

namespace RoomsEnglish.Application.PlayerContext.GetPlayers;

public class PlayersMappingProfile : Profile
{
    public PlayersMappingProfile()
    {
        //CreateMap<PlayerViewModel, GetPlayerByIdQuery>();
        CreateMap<Guid, GetPlayersQuery>();
    }
}
