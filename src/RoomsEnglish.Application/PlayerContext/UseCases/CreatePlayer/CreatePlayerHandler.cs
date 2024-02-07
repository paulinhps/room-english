

using AutoMapper;

using FluentValidation;

using Microsoft.Extensions.Logging;

using RoomsEnglish.Application.SharedContext.Extensions;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.PlayerContext.Services;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;

public class CreatePlayerHandler : HandlerBase<CreatePlayerCommand, DataApplicationResponse<PlayerInfo>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IValidator<Player> _userValidation;
    private readonly ISecurityService _securityService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreatePlayerHandler(IPlayerRepository playerRepository,
                               IValidator<Player> userValidation,
                               ISecurityService securityService,
                               IMapper mapper,
                               ILogger<CreatePlayerHandler> logger,
                               INotificationContext notificationContext)
                               : base(notificationContext)
    {
        _playerRepository = playerRepository;
        _userValidation = userValidation;
        _securityService = securityService;
        _mapper = mapper;
        _logger = logger;
    }
    public override async Task<DataApplicationResponse<PlayerInfo>> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
    {

        // 1 - Fast Validation (validando via behavior)
        // 2 - Validar se o usuário não existe
        try
        {
            if (await _playerRepository.ExistsPlayerWithEmailAsync(command.Email))
            {
                NotificationContext.AddNotification(
                    "PlayerFound",
                    "Usuario encontrado na base");
            }
        }
        catch (Exception ex)
        {
            NotificationContext.ErrorResponseType = EResponseType.ProccessError;
            _logger.LogError(ex, "An error occurred when trying to query a player");
            NotificationContext.AddNotification("DbException", "Erro ao consultar Player existente na base");
        }

        if (NotificationContext.ExistsNotifications) return default!;

        // 3 - Instanciar um objeto do tipo ApplicationUser (Player)
        var password = _securityService.GeneratePassword(command.Password);

        Player player = new(command.Email, password.Hash, command.Name);
        // 4 - Validar se a intancia e valida
        var validationResult = _userValidation.Validate(player);

        if (!validationResult.IsValid)
            NotificationContext.AddNotifications(validationResult.Errors.GetNotifications());

        // 5 - Armazenar o Player na base
        if (!NotificationContext.ExistsNotifications)
        {
            try
            {
                _ = await _playerRepository.CreatePlayerAsync(player);

                return ApplicationResponses.CreateResponse(
                    data: _mapper.Map<PlayerInfo>(player),
                    responseType: EResponseType.Created,
                    "Success to create a player");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when trying to create a player");
                NotificationContext.AddNotification("DbException",
                "An error occurred when trying to create a player");
            }
        }
        NotificationContext.ErrorResponseType = EResponseType.ProccessError;

        return default!;

    }
}
