using RoomsEnglish.Domain.SharedContext.Models;

public static class NotificationContextExtensions
{
    public static void AddNotification(this INotificationContext notificationContext, string key, string message)
        => notificationContext.AddNotification(new Notification(key, message));

}
