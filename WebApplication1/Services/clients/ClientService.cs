using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.clients;

namespace WebApplication1.Services.clients;

public class ClientsService : IClientsService
{
    private IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository repository, IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }
    public async Task<ClientDTO> DeleteClient(int idClient)
    {
        if (await _clientsRepository.ClientHasTrip(idClient))
        {
            throw new ClientHasTripException("Client id: '" + idClient + "' can't be deleted! Given client has trips!");
        }
        return await _clientsRepository.DeleteClient(idClient);
    }
}