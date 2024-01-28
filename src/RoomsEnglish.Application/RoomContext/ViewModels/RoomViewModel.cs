using System.ComponentModel.DataAnnotations;

namespace RoomsEnglish.Application.RoomContext.ViewModels;

public class RoomViewModel
{
    [Required]
    public string Name { get; set; }

    public RoomViewModel(string name)
    {
        Name = name;
    }
}