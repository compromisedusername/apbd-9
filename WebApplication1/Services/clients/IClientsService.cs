using WebApplication1.Models;

namespace WebApplication1.Services.clients;

public interface IClientsService
{
    public Task<ClientDTO> DeleteClient(int idClient);
}