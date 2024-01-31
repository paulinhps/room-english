using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.SharedContext.Extensions;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;

public class CreatePlayerHandler : HandlerBase<CreatePlayerCommand, DataApplicationResponse<PlayerInfo>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IValidator<Player> _userValidation;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreatePlayerHandler(IPlayerRepository playerRepository,
                               IValidator<Player> userValidation,
                               IMapper mapper,
                               ILogger<CreatePlayerHandler> logger,
                               INotificationContext notificationContext)
                               : base(notificationContext)
    {
        _playerRepository = playerRepository;
        _userValidation = userValidation;
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
            _logger.LogError(ex, "An error occurred when trying to query a player");
            NotificationContext.AddNotification("DbException", "Erro ao consultar Player existente na base");
        }

        if (NotificationContext.ExistsNotifications)
        {
            return ApplicationResponses.CreateResponse<PlayerInfo>(
              EResponseType.ProccessError,
              "Failed to create a player",
              NotificationContext.GetErrors());

        }
        // 3 - Instanciar um objeto do tipo ApplicationUser (Player)
        Player user = new(command.Email, command.Password, command.Name);
        // 4 - Validar se a intancia e valida
        var validationResult = _userValidation.Validate(user);

        if (!validationResult.IsValid)
            NotificationContext.AddNotifications(validationResult.Errors.GetNotifications());

        // 5 - Armazenar o Player na base
        if (!NotificationContext.ExistsNotifications)
        {
            try
            {
                _ = await _playerRepository.CreatePlayerAsync(user);

                return ApplicationResponses.CreateResponse(
                    data: _mapper.Map<PlayerInfo>(user),
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

        return ApplicationResponses.CreateResponse<PlayerInfo>(EResponseType.ProccessError, "Failed to create a player", NotificationContext.GetErrors());

    }
}