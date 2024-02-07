using FluentValidation;

using MediatR;

using RoomsEnglish.Application.SharedContext.Extensions;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class ValidationApplicationRequestBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
where TResult : ApplicationResponse, new()
where TCommand : notnull, AbstractRequest<TResult>
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;
    private readonly INotificationContext _notification;

    public ValidationApplicationRequestBehavior(IEnumerable<IValidator<TCommand>> validators, INotificationContext notification)
    {
        _validators = validators;
        _notification = notification;
    }
    public async Task<TResult> Handle(TCommand request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {

        var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(f => f != null)
                .ToList();

        if (failures.Any())
        {

            var errorCommandResult = new TResult()
            {
                ResponseType = EResponseType.InputedError,
                Message = "request is not valid",
                Errors = failures.GetErrors()
            };

            return errorCommandResult;

        }

        var result = await next();

        if (_notification.ExistsNotifications)
        {
            try
            {
                var errorCommandResult = new TResult()
                {
                    ResponseType = _notification.ErrorResponseType,
                    Message = "request is not valid",
                    Errors = _notification.GetErrors()
                };
                return errorCommandResult;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        return result;
    }
}
