using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ExceptionDTO
{
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; } 

}