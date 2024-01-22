using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public class PlayerViewModel
{
    [Required]
    public string Name { get; set; }

    public PlayerViewModel(string name)
    {
        Name = name;
    }
}