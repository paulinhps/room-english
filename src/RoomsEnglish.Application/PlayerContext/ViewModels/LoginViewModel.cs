using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public record LoginViewModel
{
    [Required(ErrorMessage = "{0} is required")]
    [EmailAddress]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
