using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public record LoginViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [EmailAddress]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}