using AutoMapper;
using MediatR;
using RoomsEnglish.Api.Constants;
using RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;
using RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;
using RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

public static class PlayerEndpoints
{
    private readonly static string[] s_tags = ["Player"];

    public static void MapPlayerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointPathMapping.Players, async (CreatePlayerViewModel createPlayer, IMapper mapper, IMediator bus) =>
        {
            var result = await bus.Send(mapper.Map<CreatePlayerCommand>(createPlayer));

            if (result.Success) return Results.Created($"{EndpointPathMapping.Players}/{result.Data!.PlayerId}", result);

            return Results.BadRequest(result);
        }).WithName("CreatePlayer")
            .WithTags(s_tags);

        //Get Players
        endpoints.MapGet($"{EndpointPathMapping.Players}", async (IMapper mapper, IMediator bus) =>
        {
            var command = new GetPlayersQuery();
            var result = await bus.Send(command);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        });

        //Get Player Id
        endpoints.MapGet($"{EndpointPathMapping.Players}/{{id:guid}}", async (Guid id, IMapper mapper, IMediator bus) =>
        {
            //TODO: Validar o GUID
            if (id == Guid.Empty)
                return Results.BadRequest("id não pode ser nulo");
            var command = mapper.Map<GetPlayerByIdQuery>(id);
            var result = await bus.Send(command);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        }).WithName("CreatePlayerId")
            .WithTags(s_tags);
        
    }
}