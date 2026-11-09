using System.ComponentModel.DataAnnotations;

namespace bee_m223_auftrag2_3.Models;
public class MovieDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; }
    public List<User>? Users { get; set; }
    public List<Map>? Maps { get; set; }
}