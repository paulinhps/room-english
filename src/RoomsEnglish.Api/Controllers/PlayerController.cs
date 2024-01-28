using Microsoft.AspNetCore.Mvc;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    [HttpGet]
    [Route("Players")]
    public IActionResult GetPlayers([FromQuery] int? id)
    {
        return id == null ? Ok() : Ok(id);
    }

    [HttpPost]
    [Route("Create")]
    public ActionResult CreatePlayer([FromBody] PlayerViewModel Player)
    {
        return Ok(Player);
    }

    [HttpPut]
    [Route("Update")]
    public ActionResult UpdatePlayer([FromBody] PlayerViewModel Player)
    {
        return Ok(Player);
    }

    [HttpDelete]
    [Route("Delete")]
    public ActionResult DeletePlayer([FromQuery] int id)
    {
        if (id == 0) return BadRequest("Parâmetro obrigatório");

        return Ok(id);
    }
}

