using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ClientDTO
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Telephone { get; set; } = null!;
    [Required]
    public string Pesel { get; set; } = null!;
}