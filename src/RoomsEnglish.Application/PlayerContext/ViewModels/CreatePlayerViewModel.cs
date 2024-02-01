using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public class CreatePlayerViewModel
{
    //TODO: need refactor rules
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    [Length(8, 16)]
    public string Password { get; set; } = null!;

}