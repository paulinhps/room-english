namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class RequestCommand : AbstractRequestCommand<ApplicationResponse> { }

public abstract class RequestCommand<TResult> : AbstractRequestCommand<DataApplicationResponse<TResult>> { }
