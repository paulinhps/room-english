using AutoMapper;
using MediatR;
using RoomsEnglish.Application.AccountContext.LoginIn;

namespace RoomsEnglish.Api.AccountContext;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder endpoints) {

        endpoints.MapPost("/auth/token", async (LoginViewModel loginViewModel, IMapper mapper, IMediator bus) => {

            var command = mapper.Map<AuthUserCommand>(loginViewModel);

            var result = await bus.Send(command);

            // TODO: create a standardized return
            return Results.Ok(result);

        });

    }
}

