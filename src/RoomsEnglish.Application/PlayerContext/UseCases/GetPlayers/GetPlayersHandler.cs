using AutoMapper;

using Microsoft.Extensions.Logging;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;
public class GetPlayersHandler : HandlerBase<GetPlayersQuery, DataApplicationResponse<IEnumerable<PlayerViewModel>>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    public GetPlayersHandler(IPlayerRepository playerRepository, ILogger<GetPlayersHandler> logger, IMapper mapper, INotificationContext notification)
        : base(notification)
    {
        _playerRepository = playerRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async override Task<DataApplicationResponse<IEnumerable<PlayerViewModel>>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        try
        {
            var players = await _playerRepository.GetPlayersAsync(cancellationToken);
            var playersViewModel = _mapper.Map<IEnumerable<PlayerViewModel>>(players);
            return ApplicationResponses.CreateResponse(playersViewModel, EResponseType.Success, "Retornando lista de pessoas");
        }
        catch (Exception ex)
        {
            const string msg = "player not found.";
            _logger.LogError(ex, msg);
            NotificationContext.ErrorResponseType = EResponseType.ProccessError;
            NotificationContext.AddNotification(new Notification("GetPlayersError", msg));
            return default!;
        }
    }
}