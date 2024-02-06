using AutoMapper;

using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

public sealed class NotificationContext : INotificationContext
{
    private readonly IMapper _mapper;
    private readonly List<Notification> _notifications;

    public IReadOnlyList<Notification> Notifications => _notifications;

    public NotificationContext(IMapper mapper)
    {
        _notifications = new();
        _mapper = mapper;
    }
    public void AddNotification(Notification notification)
    => AddNotifications(notification);

    public bool ExistsNotifications => _notifications.Any();

    public EResponseType ErrorResponseType { get; set; } = EResponseType.InputedError;

    public IEnumerable<Notification> GetNotifications() => _notifications;
    public Error[] GetErrors()
    {
        var errors = _mapper.Map<IEnumerable<Error>>(_notifications).ToArray();

        return errors;
    }

    public void AddNotifications(params Notification[] notifications)
    {
        _notifications.AddRange(notifications);
    }
}