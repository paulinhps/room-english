using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomsEnglish.Application.PlayerContext.PlayerGetId;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

[Route("api/[controller]")]
public static class PlayerEndpoints
{
    public static void MapPlayerEndpoints(this IEndpointRouteBuilder endpoints)
    {
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