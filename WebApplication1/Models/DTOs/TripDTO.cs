using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class TripDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public int MaxPeople { get; set; }
    [Required]
    public IEnumerable<ClientDTO> Clients { get; set; }
}