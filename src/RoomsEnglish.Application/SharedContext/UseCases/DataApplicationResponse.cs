using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public class DataApplicationResponse<TData> : ApplicationResponse
{
    public TData? Data { get; }

    public DataApplicationResponse() : base()
    {

    }
    public DataApplicationResponse(TData? data, EResponseType responseType, string message, params Error[] errors) : base(responseType, message, errors)
    {
        Data = data;
    }

}
