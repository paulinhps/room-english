using MediatR;

using Microsoft.Extensions.Logging;

using RoomsEnglish.Application.Data;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class UnitOfWorkBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
where TResult : ApplicationResponse
where TCommand : notnull, AbstractRequestCommand<TResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly INotificationContext _notificationContext;
    private readonly ILogger<UnitOfWorkBehavior<TCommand, TResult>> _logger;

    public UnitOfWorkBehavior(
        IApplicationDbContext dbContext,
        INotificationContext notificationContext,
        ILogger<UnitOfWorkBehavior<TCommand, TResult>> logger)
    {
        _dbContext = dbContext;
        _notificationContext = notificationContext;
        _logger = logger;
    }
    public async Task<TResult> Handle(TCommand request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        try
        {
            var result = await next();

            if (!_notificationContext.ExistsNotifications)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "an unexpected error occurred");

            return (TResult)ApplicationResponses.CreateResponse(
                responseType: EResponseType.ProccessError,
                message: "an unexpected error occurred"
            );
        }
    }
}