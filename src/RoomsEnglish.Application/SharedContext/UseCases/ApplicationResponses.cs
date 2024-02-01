using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public static class ApplicationResponses {

    public static ApplicationResponse CreateResponse(EResponseType responseType, string message, params Error[] errors) 
    => new DefaultApplicatonResponse(responseType, message, errors);

    public static DataApplicationResponse<TData> CreateResponse<TData>(EResponseType responseType, string message, params Error[] errors) 
    => CreateResponse<TData>(default, responseType, message, errors);

    public static DataApplicationResponse<TData> CreateResponse<TData>(TData? data, EResponseType responseType, string message, params Error[] errors) 
    => new DefaultDataApplicatonResponse<TData>(data, responseType, message, errors);

    private class DefaultApplicatonResponse : ApplicationResponse
    {
        public DefaultApplicatonResponse(EResponseType responseType, string message, params Error[] errors) : base(responseType, message, errors)
        {
        }
    }
    
    private class DefaultDataApplicatonResponse<TData> : DataApplicationResponse<TData>
    {
        public DefaultDataApplicatonResponse(TData? data, EResponseType responseType, string message, params Error[] errors) : base(data, responseType, message, errors)
        {
        }
    }
}
