using WebApplication1.Models;

namespace WebApplication1.Services.clients;

public interface IClientsService
{ 
    Task<ClientDTO> DeleteClient(int idClient, CancellationToken cancellationToken);
}