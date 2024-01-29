using AutoMapper;
using MediatR;
using RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // TODO: Configue api documentation
        endpoints.MapPost("/auth/token", async (LoginViewModel loginViewModel, IMapper mapper, IMediator bus) =>
        {

            var command = mapper.Map<LoginCommand>(loginViewModel);

            var result = await bus.Send(command);

            // TODO: create a standardized return
            return Results.Ok(result);

        });

    }
}

