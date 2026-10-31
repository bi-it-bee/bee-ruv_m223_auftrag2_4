using System.ComponentModel.DataAnnotations;

namespace bee_m223_auftrag2_3.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}