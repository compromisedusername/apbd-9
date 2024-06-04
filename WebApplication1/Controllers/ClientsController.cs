using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.clients;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    
    //todo ogarnac middlewary
    
    private readonly IClientsService _clientService;

    public ClientsController(IClientsService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient:int}")]
    public async Task<IActionResult> DeleteClient(int idClient, CancellationToken cancellationToken)
    {
            return Ok(new { DeletedClient = await _clientService.DeleteClient(idClient, cancellationToken) });
    }

   
}

