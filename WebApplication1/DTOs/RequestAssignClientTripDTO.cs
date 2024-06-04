using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class RequestAssignClientTripDTO
{
    

    [Required] 
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Telephone { get; set; }
    [Required]
    public string Pesel { get; set; }
    [Required]
    public string TripName { get; set; }

    [Timestamp] public DateTime? PaymentDate { get; set; }
}