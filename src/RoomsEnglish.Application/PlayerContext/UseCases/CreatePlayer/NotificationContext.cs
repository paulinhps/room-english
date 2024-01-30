using AutoMapper;
using RoomsEnglish.Domain.SharedContext.Models;

public sealed class NotificationContext : INotificationContext
{
    private readonly IMapper _mapper;
    private List<Notification> _notifications;

    public IReadOnlyList<Notification> Notifications => _notifications;

    public NotificationContext(IMapper mapper)
    {
        _notifications = new();
        _mapper = mapper;
    }
    public void AddNotification(Notification notification)
    => AddNotifications(notification);

    public bool ExistsNotifications => _notifications.Any();

    public IEnumerable<Notification> GetNotifications() => _notifications;
    public Error[] GetErrors()
        => _mapper.Map<IEnumerable<Error>>(_notifications).ToArray();

    public void AddNotifications(params Notification[] notifications)
    {
        _notifications.AddRange(notifications);
    }
}
