using Microsoft.AspNetCore.Mvc;
using RoomsEnglish.Api.ViewModels;

namespace RoomsEnglish.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    [HttpGet]
    [Route("Rooms")]
    public IActionResult GetRooms([FromQuery] int? id)
    {
        return id == null ? Ok() : Ok(id);
    }

    [HttpPost]
    [Route("Create")]
    public ActionResult CreateRoom([FromBody] RoomViewModel room)
    {
        return Ok(room);
    }

    [HttpPut]
    [Route("Update")]
    public ActionResult UpdateRoom([FromBody] RoomViewModel room)
    {
        return Ok(room);
    }

    [HttpDelete]
    [Route("Delete")]
    public ActionResult DeleteRoom([FromQuery] int id)
    {
        if (id == 0) return BadRequest("Parâmetro obrigatório");

        return Ok(id);
    }
}

