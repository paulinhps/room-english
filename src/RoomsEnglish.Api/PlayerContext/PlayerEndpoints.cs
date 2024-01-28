using AutoMapper;
using MediatR;
using RoomsEnglish.Application.PlayerContext.PlayerGetId;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.PlayerContext;

public static class PlayerEndpoints
{
    public static void MapPlayerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // TODO: Configue api documentation
        endpoints.MapGet("/players/{id?}", async (Guid? id, PlayerViewModel playerViewModel, IMapper mapper, IMediator bus) =>
        {
            if (id != null)
            {
                var command = mapper.Map<PlayerCommand>(playerViewModel);
                var result = await bus.Send(command);

                // TODO: create a standardized return
                return Results.Ok(result);
            }
            else
            {
                // TODO: create a standardized return
                // var result = await bus.Send(command);
                // return Results.Ok(result);
                return Results.Ok();
            }
        });

        endpoints.MapDelete("/player/{id}", async (Guid id, PlayerViewModel playerViewModel, IMapper mapper, IMediator bus) =>
       {
           //if (id != null)
           //{
           //    var command = mapper.Map<PlayerCommand>(playerViewModel);
           //    var result = await bus.Send(command);

           //    // TODO: create a standardized return
           //    return Results.Ok(result);
           //}
           //else
           //{
           //    // TODO: create a standardized return
           //    // var result = await bus.Send(command);
           //    // return Results.Ok(result);
           //    return Results.Ok();
           //}
       });
    }
}