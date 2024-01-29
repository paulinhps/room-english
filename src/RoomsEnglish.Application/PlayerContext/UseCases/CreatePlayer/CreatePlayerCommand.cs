using FluentValidation;
using MediatR;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.SharedContext.Models;
using RoomsEnglish.Domain.SharedContext.UseCases;
using RoomsEnglish.Domain.UserContext.Entities;

public class CreatePlayerCommand : IRequest<PlayerInfo>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}

public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, PlayerInfo>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IValidator<ApplicationUser> _userValidation;
    private readonly INotificationContext _notificationContext;

    public CreatePlayerHandler(IPlayerRepository playerRepository, IValidator<ApplicationUser> userValidation, INotificationContext notificationContext)
    {
        _playerRepository = playerRepository;
        _userValidation = userValidation;
        _notificationContext = notificationContext;
    }
    public async Task<PlayerInfo> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
    {

        // 1 - Fast Validation (validando via behavior)
        // 2 - Validar se o usuário não existe
        try
        {
            if (await _playerRepository.ExistsPlayerWithEmail(command.Email))
            {
                _notificationContext.AddNotification(new()
                {
                    Key = "PlayerFound",
                    Message = "Usuario encontrado na base"
                });
            }
        }
        catch (System.Exception)
        {
            _notificationContext.AddNotification(new()
            {
                Key = "DbException",
                Message = "Erro ao consultar Player existente na base"
            });
        }

        if (_notificationContext.ExistsNotification())
        {
            // parar por aqui e retornar os errors
        }
        // 3 - Instanciar um objeto do tipo ApplicationUser (Player)
        ApplicationUser user = new(command.Email, command.Password, command.Name);
        // 4 - Validar se a intancia e valida
        var validationResult = _userValidation.Validate(user);
        // 5 - Armazenar o Player na base

        if (!validationResult.IsValid)
        {

            _notificationContext.AddNotification(new()
            {
                Key = "DbException",
                Message = "Erro ao consultar Player existente na base"
            });

        }

        if (!_notificationContext.ExistsNotification())
        {

            try
            {
                _ = await _playerRepository.CreatePlayer(user);
                return new PlayerInfo()
                {
                    PlayerId = user.Id,
                    Name = user.Name,
                    Email = user.Email.Address
                };
            }
            catch (System.Exception)
            {

                _notificationContext.AddNotification(new()
                {
                    Key = "DbException",
                    Message = "Erro ao consultar Player existente na base"
                });

            }
        }

        return new PlayerInfo(_notificationContext.GetNotifications().Select(c => new Error()
        {
            Key = c.Key,
            Message = c.Message
        }).ToArray());

    }
}


public class PlayerInfo : CommandResult
{
    public PlayerInfo(params Error[] errors) : base(errors)
    {

    }
    public Guid PlayerId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public interface INotificationContext
{

    void AddNotification(Notification notification);
    bool ExistsNotification();

    IEnumerable<Notification> GetNotifications();
}

public class NotificationContext : INotificationContext
{
    private List<Notification> notifications;

    public NotificationContext()
    {
        notifications = new();
    }
    public void AddNotification(Notification notification)
    {
        notifications.Add(notification);
    }

    public bool ExistsNotification() => notifications.Any();

    public IEnumerable<Notification> GetNotifications() => notifications;
}

public class Notification
{
    public string Key { get; set; } = null!;
    public string Message { get; set; } = null!;
}