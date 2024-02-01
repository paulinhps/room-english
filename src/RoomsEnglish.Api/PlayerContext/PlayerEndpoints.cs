using AutoMapper;

using MediatR;

using RoomsEnglish.Api.Constants;
using RoomsEnglish.Application.PlayerContext.PlayerGetId;
using RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

public static class PlayerEndpoints
{
    private readonly static string[] s_tags = ["Players"];

    public static void MapPlayerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointPathMapping.Players, async (CreatePlayerViewModel createPlayer, IMapper mapper, IMediator bus) => {
               var result = await bus.Send(mapper.Map<CreatePlayerCommand>(createPlayer));

               if(result.Success) return Results.Created($"{EndpointPathMapping.Players}/{result.Data!.PlayerId}", result);

               return Results.BadRequest(result);
        }).WithName("CreatePlayer")
            .WithTags(s_tags);

       
    }
}

