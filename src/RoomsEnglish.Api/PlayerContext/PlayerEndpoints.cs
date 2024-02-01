using AutoMapper;
using MediatR;
using RoomsEnglish.Api.Constants;
using RoomsEnglish.Application.PlayerContext.GetPlayerInfo;
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

       
        // TODO: Configue api documentation
        endpoints.MapGet("players",
            async (IMapper mapper, IMediator bus) =>
            {
                return Results.Ok();
            });
        
        endpoints.MapGet("player/{id:guid}", async (Guid id, IMapper mapper, IMediator bus) =>
        {
            //TODO: Validar o GUID
            
            var command = mapper.Map<GetPlayerByIdQuery>(id);
            var result = await bus.Send(command);

            // TODO: create a standardized return
            return Results.Ok(result);
        });

        endpoints.MapPost("Create", async (PlayerViewModel playerViewModel, IMapper mapper, IMediator bus) =>
        { 
            await Task.Delay(1000);
            return Results.Ok();
        });
        
        endpoints.MapPut("Update", async (PlayerViewModel playerViewModel, IMapper mapper, IMediator bus) => { 
            await Task.Delay(1000);
            return Results.Ok();
        });
        
        endpoints.MapDelete("Delete", async (Guid id, IMapper mapper, IMediator bus) =>
        {
            await Task.Delay(1000);
            return Results.Ok();
        });
    }
}

