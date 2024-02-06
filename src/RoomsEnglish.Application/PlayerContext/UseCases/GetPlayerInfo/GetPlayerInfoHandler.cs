using AutoMapper;

using Microsoft.Extensions.Logging;

using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;

public class GetPlayerInfoHandler : HandlerBase<GetPlayerByIdQuery, DataApplicationResponse<PlayerViewModel>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetPlayerInfoHandler(IPlayerRepository playerRepository, ILogger<GetPlayerInfoHandler> logger, IMapper mapper, INotificationContext notification)
        : base(notification)
    {
        _playerRepository = playerRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async override Task<DataApplicationResponse<PlayerViewModel>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        try
        {
            var players = await _playerRepository.FindPlayerByIdAsync(request.Id, cancellationToken);
            if (players == null)
            {
                const string msg = "player not exist.";
                NotificationContext.ErrorResponseType = EResponseType.NotFoundError;
                NotificationContext.AddNotification(new Notification("GetPlayerInfoError", msg));
                return default!;
            }
            var playersViewModel = _mapper.Map<PlayerViewModel>(players);
            return ApplicationResponses.CreateResponse(playersViewModel, EResponseType.Success, "Retornando lista de pessoas");
        }
        catch (Exception ex)
        {
            const string msg = "player not exist.";
            _logger.LogError(ex, msg);
            NotificationContext.ErrorResponseType = EResponseType.ProccessError;
            NotificationContext.AddNotification(new Notification("GetPlayerInfoError", msg));
            return default!;
        }
    }
}