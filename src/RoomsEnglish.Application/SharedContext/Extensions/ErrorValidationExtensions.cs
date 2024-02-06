using FluentValidation.Results;

using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.SharedContext.Extensions;

public static class ErrorValidationExtensions
{
    public static Notification[] GetNotifications(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures.Select(failure => new Notification(failure.PropertyName, failure.ErrorMessage)).ToArray();
    }
    public static Error[] GetErrors(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures.Select(failure => new Error(failure.PropertyName, failure.ErrorMessage)).ToArray();
    }
}