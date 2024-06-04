using WebApplication1.Models;

namespace WebApplication1.Repositories.clients;

public interface IClientsRepository
{

    Task<bool> ClientHasTrip(int idClient, CancellationToken cancellationToken);
    Task<ClientDTO> DeleteClient(int idClient, CancellationToken cancellationToken);
    Task<int> AssignClientToTrip(RequestAssignClientTrip data, int idClient, CancellationToken cancellationToken);
    Task<int> ClientExists(string dataPesel, CancellationToken cancellationToken);
    Task<bool> IsClientAssignedToTrip(string dataPesel, int dataIdTrip, CancellationToken cancellationToken);
}