using MediatR;
using Microsoft.Extensions.Logging;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;
public class GetPlayersHandler : 
    //HandlerBase<LoginPlayerCommand, DataApplicationResponse<LoginPlayerResult>>
    IRequestHandler<GetPlayersQuery, QueryResult<IEnumerable<PlayerViewModel>>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly INotificationContext _notification;
    public GetPlayersHandler(IPlayerRepository playerRepository, ILogger<GetPlayersHandler> logger, IMapper mapper, INotificationContext notification)
    {
        _playerRepository = playerRepository;
        _logger = logger;
        _mapper = mapper;
        _notification = notification;
    }

    public async Task<QueryResult<IEnumerable<PlayerViewModel>>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        try
        {
            var players = await _playerRepository.GetPlayersAsync(cancellationToken);
            var playersViewModel = _mapper.Map<IEnumerable<PlayerViewModel>>(players);
            return new QueryResult<IEnumerable<PlayerViewModel>>()
            {
                Data = playersViewModel
            };
        }
        catch (Exception ex)
        {
            const string msg = "player not found."; 
            _logger.LogError(ex, msg);
            _notification.ErrorResponseType = EResponseType.ProccessError;
            _notification.AddNotification(new Notification("not found GetPlayers", msg));
            return default!;
        }
    }
}
