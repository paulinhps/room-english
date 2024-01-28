using AutoMapper;
using FluentValidation;
using MediatR;

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

public abstract class CommandResult
{
    public IEnumerable<Error> Errors { get; set; }
    protected CommandResult(params Error[] errors)
    {
        Errors = errors;
    }
    public string? Message { get; set; }

}

public class Error
{
    public string? Key { get; set; }
    public string? Message { get; set; }
}

public class ErrorCommandResult : CommandResult
{

    public ErrorCommandResult(string message, params Error[] errors) : base(errors)
    {
        Message = message;
    }

}