namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class AbstractRequestCommand<TResponse> : AbstractRequest<TResponse>
where TResponse : ApplicationResponse
{

}
