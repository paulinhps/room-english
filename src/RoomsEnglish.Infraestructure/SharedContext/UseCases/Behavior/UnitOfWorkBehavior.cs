using MediatR;
using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.SharedContext.UseCases;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class UnitOfWorkBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
where TResult : CommandResult
where TCommand : notnull
{
    private readonly IApplicationDbContext _dbContext;
    private readonly INotificationContext notificationContext;

    public UnitOfWorkBehavior(IApplicationDbContext dbContext, INotificationContext notificationContext)
    {
        _dbContext = dbContext;
        this.notificationContext = notificationContext;
    }
    public async Task<TResult> Handle(TCommand request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        try
        {
            var result = await next();

            if (!notificationContext.ExistsNotification())
            {

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return result;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
