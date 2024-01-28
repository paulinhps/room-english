using MediatR;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.PlayerContext.LoginPlayer;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;

public class PlayerHandler : IRequestHandler<PlayerCommand, PlayerResult>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ISecurityService _securityService;
    private readonly ILogger<LoginHandler> _logger;

    public PlayerHandler(IPlayerRepository playerRepository, ISecurityService securityService, ILogger<LoginHandler> logger)
    {
        _playerRepository = playerRepository;
        _securityService = securityService;
        _logger = logger;
    }

    public async Task<PlayerResult> Handle(PlayerCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        IApplicationUser user = default!;

        try
        {
            user = (IApplicationUser)await _playerRepository.FindPlayerById(request.Id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "player not found.");
            // TODO: Implements error results
        }

        // TODO: Change this to Autommaper
        return new PlayerResult()
        {
            Id = user.Id,
            Message = "success!"
        };
    }
}
