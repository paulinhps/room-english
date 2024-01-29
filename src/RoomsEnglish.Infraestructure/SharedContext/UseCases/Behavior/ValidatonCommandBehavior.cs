using AutoMapper;
using FluentValidation;
using MediatR;
using RoomsEnglish.Domain.SharedContext.Models;
using RoomsEnglish.Domain.SharedContext.UseCases;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class ValidatonCommandBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
where TResult : CommandResult
where TCommand : notnull
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;
    private readonly IMapper _mapper;

    public ValidatonCommandBehavior(IEnumerable<IValidator<TCommand>> validators, IMapper mapper)
    {
        _validators = validators;
        _mapper = mapper;
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

            IEnumerable<Error> errors = _mapper.Map<IEnumerable<Error>>(failures);

            var errorCommandResult = new ErrorCommandResult("command is not valid", errors.ToArray()) as TResult;

            return Task.FromResult(errorCommandResult!);
        }

        return next();
    }
}
