using WebApplication1.Models;

namespace WebApplication1.Repositories.clients;

public interface IClientsRepository
{
    Task<bool> ClientHasTrip(int idClient);
    Task<ClientDTO> DeleteClient(int idClient);
}