using MediatR;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Domain.PlayerContext.Repositories;

namespace RoomsEnglish.Application.PlayerContext.GetPlayers;
public class GetPlayersHandler : IRequestHandler<GetPlayersQuery, QueryResult<IEnumerable<PlayerViewModel>>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetPlayersHandler(IPlayerRepository playerRepository, ILogger<GetPlayersHandler> logger, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _logger = logger;
        _mapper = mapper;
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
            _logger.LogError(ex, "player not found.");
            // TODO: Implements error results
            return new QueryResult<IEnumerable<PlayerViewModel>>()
            {
                MessageCode = 400,
                Message = "error!",
            };
        }
    }
}
