
using MediatR;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class AbstractRequest<TResponse> : IRequest<TResponse>
 where TResponse : ApplicationResponse
{

}