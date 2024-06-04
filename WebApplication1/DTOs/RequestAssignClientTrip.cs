using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models;

public class RequestAssignClientTrip
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
    [Required]
    public int IdTrip { get; set; }
    [Timestamp] public DateTime? PaymentDate { get; set; }
    
    
  
}