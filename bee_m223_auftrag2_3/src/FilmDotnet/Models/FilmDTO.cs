using System.ComponentModel.DataAnnotations;

namespace bee_m223_auftrag2_3.Models;
public class FilmDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LengthMinutes { get; set; }
    public string Description { get; set; }
}