using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Repositories.clients;

namespace WebApplication1.Services.clients;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;
    private readonly ITripsRepository _tripsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientsService( IClientsRepository clientsRepository, ITripsRepository tripsRepository, IUnitOfWork unitOfWork)
    {
        _clientsRepository = clientsRepository;
        _tripsRepository = tripsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ClientDTO> DeleteClient(int idClient, CancellationToken cancellationToken)
    {
        await _unitOfWork.InitializeAsync(cancellationToken);
        
        if (await _clientsRepository.ClientHasTrip(idClient, cancellationToken))
        {
            throw new DomainException("Client id: '" + idClient + "' can't be deleted! Given client has trips!");
        }

        await _unitOfWork.CommitAsync(cancellationToken);
        
        return await _clientsRepository.DeleteClient(idClient, cancellationToken);
    }

   
}