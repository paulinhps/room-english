using RoomsEnglish.Application.SharedContext.UseCases;

namespace RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;

public class CreatePlayerCommand : RequestCommand<PlayerInfo>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}
