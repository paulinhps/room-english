using MediatR;
using RoomsEnglish.Application.SharedContext.UseCases;

public class CreatePlayerCommand : IRequest<DataApplicationResponse<PlayerInfo>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}
