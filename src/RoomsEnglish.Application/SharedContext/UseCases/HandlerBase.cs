using MediatR;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : notnull, IRequest<TResponse>
{
    protected INotificationContext NotificationContext { get; }

    protected HandlerBase(INotificationContext notificationContext)
    {
        NotificationContext = notificationContext;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

