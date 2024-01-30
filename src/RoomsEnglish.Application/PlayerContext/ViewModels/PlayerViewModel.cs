using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public class PlayerViewModel(string name, Guid? id)
{
    [Required(ErrorMessage = "{0} is required")]
    public Guid? Id { get; set; } = id;

    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; } = name;
}