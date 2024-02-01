using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

public interface INotificationContext
{
    IReadOnlyList<Notification> Notifications { get;}
    bool ExistsNotifications {get;}
    void AddNotification(Notification notification);
    void AddNotifications(params Notification[] notifications);
    Error[] GetErrors();
    IEnumerable<Notification> GetNotifications();

    EResponseType ErrorResponseType { get; set; } 
}

