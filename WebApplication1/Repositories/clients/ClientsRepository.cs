using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Repositories.clients;

public class ClientsRepository : BaseRepository, IClientsRepository
{
    
    public async Task<bool> ClientHasTrip(int idClient, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.ClientTrips.AnyAsync(e => e.IdClient == idClient, cancellationToken);
    }

    public async Task<ClientDTO> DeleteClient(int idClient, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Context.Clients.FindAsync(idClient);

        if (client == null)
        {
            throw new KeyNotFoundException("Client not found.");
        }

        _unitOfWork.Context.Clients.Remove(client);

        await _unitOfWork.Context.SaveChangesAsync(cancellationToken);

        return new ClientDTO()
        {
            Email = client.Email,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Pesel = client.Pesel,
            Telephone = client.Telephone
        };
    }

    public async Task<int> AssignClientToTrip(RequestAssignClientTrip data, int idClient, CancellationToken cancellationToken)
    {
        var clientTrip = new ClientTrip
        {
            IdClient = idClient,
            IdTrip = data.IdTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = data.PaymentDate 
        };

        // Add the record and save changes
        await _unitOfWork.Context.ClientTrips.AddAsync(clientTrip, cancellationToken);
        await _unitOfWork.Context.SaveChangesAsync(cancellationToken);

        return clientTrip.IdTrip;
    }

    public async Task<int> ClientExists(string dataPesel, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Context.Clients.FindAsync(dataPesel);
        if (client == null) throw new DomainException("Client doesn't exists!");
        return client.IdClient;
    }

    public async Task<bool> IsClientAssignedToTrip(string dataPesel, int dataIdTrip, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.ClientTrips.AnyAsync(ct =>
            ct.IdClientNavigation.Pesel.Equals(dataPesel) && ct.IdTrip == dataIdTrip, cancellationToken);
    }

    

  

    public ClientsRepository( IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}