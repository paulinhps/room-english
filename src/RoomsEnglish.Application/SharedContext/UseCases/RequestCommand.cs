
using MediatR;

namespace RoomsEnglish.Application.SharedContext.UseCases;


public abstract class RequestCommand : IRequest<ApplicationResponse>
{

}

public abstract class RequestCommand<TResult> : IRequest<DataApplicationResponse<TResult>>
{

}
