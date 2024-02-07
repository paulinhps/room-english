using AutoMapper;

using MediatR;

using RoomsEnglish.Api.Constants;
using RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

public static class AuthEndpoints
{

    private readonly static string[] s_tags = ["Auth"];
    public static void MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // TODO: Configue api documentation
        endpoints.MapPost($"{EndpointPathMapping.Auth}/token", async (LoginViewModel loginViewModel, IMapper mapper, IMediator bus) =>
        {

            var command = mapper.Map<LoginPlayerCommand>(loginViewModel);

            var result = await bus.Send(command);

            // TODO: create a standardized return
            return Results.Ok(result);

        }).WithName("AuthUser")
            .WithTags(s_tags);

    }
}
