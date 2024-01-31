using FluentValidation;
using MediatR;
using RoomsEnglish.Application.SharedContext.Extensions;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class ValidationApplicationRequestBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
where TResult : ApplicationResponse
where TCommand : notnull, IRequest<TResult>
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationApplicationRequestBehavior(IEnumerable<IValidator<TCommand>> validators)
    {
        _validators = validators;
    }
    public Task<TResult> Handle(TCommand request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var failures = _validators
               .Select(v => v.Validate(request))
               .SelectMany(x => x.Errors)
               .Where(f => f != null)
               .ToList();

        if (failures.Any())
        {

            var errorCommandResult = ApplicationResponses.CreateResponse(
                EResponseType.InputedError, 
                "request is not valid", failures.GetErrors()) as TResult;

            return Task.FromResult(errorCommandResult!);
        }

        return next();
    }
}
