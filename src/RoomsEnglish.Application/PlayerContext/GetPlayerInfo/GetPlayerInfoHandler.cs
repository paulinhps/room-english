using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Repositories;

namespace RoomsEnglish.Application.PlayerContext.GetPlayerInfo;

public class GetPlayerInfoHandler : IRequestHandler<GetPlayerByIdQuery, QueryResult<PlayerViewModel>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetPlayerInfoHandler(IPlayerRepository playerRepository, ILogger<GetPlayerInfoHandler> logger, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<QueryResult<PlayerViewModel>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        try
        {
            var player = await _playerRepository.FindPlayerByIdAsync(request.Id, cancellationToken);
            return new QueryResult<PlayerViewModel>()
            {
                Data = _mapper.Map<PlayerViewModel>(player)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "player not found.");
            // TODO: Implements error results
            // TODO: Change this to Autommaper
            return new QueryResult<PlayerViewModel>()
            {
                MessageCode = 400,
                Message = "error!",
            };
        }
    }
}
