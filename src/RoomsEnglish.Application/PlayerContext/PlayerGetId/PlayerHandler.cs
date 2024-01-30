using MediatR;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.PlayerContext.LoginPlayer;
using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;

public class PlayerHandler : IRequestHandler<GetPlayerByIdQuery, QueryResult<PlayerViewModel>>
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

    public async Task<QueryResult<PlayerViewModel>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        try
        {
            var player = await _playerRepository.FindPlayerById(request.Id, cancellationToken);
            //TODO: Mapper para PlayerViewModel
            var result = new QueryResult<PlayerViewModel>();
            return result;
            //result.Data = PlayerViewModel
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "player not found.");
            // TODO: Implements error results
            var errors = new QueryResult<PlayerViewModel>(
                // criar no constructor da base
            );
        }

        // TODO: Change this to Autommaper
        return new QueryResult<PlayerViewModel>()
        {
            MessageCode = 400,
            Message = "error!",
        };
    }
    
    public async Task<QueryResult<PlayerViewModel>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
