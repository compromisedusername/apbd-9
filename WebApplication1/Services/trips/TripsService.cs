using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Repositories.clients;
using WebApplication1.Services.clients;

namespace WebApplication1.Services;

public class TripsService : ITripsService
{
    private ITripsRepository _tripsRepository;
    private IClientsRepository _clientsRepository;
    private IUnitOfWork _unitOfWork;

    public TripsService(ITripsRepository repository, IUnitOfWork unitOfWork)
    {
        _tripsRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize, CancellationToken cancellationToken)
    {
        await _unitOfWork.InitializeAsync(cancellationToken);
        var res = await _tripsRepository.GetTrips(page, pageSize, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return res;
    }

    public async Task<PageDTO> GetPagingInfo(int page, int pageSize, CancellationToken cancellationToken)
    {
        await _unitOfWork.InitializeAsync(cancellationToken);
        if ( page <= 0)
        {
            throw new DomainException("Invalid 'page' parameter. It must be a positive integer.");
        }if ( pageSize <= 0)
        {
            throw new DomainException("Invalid 'pageSize' parameter. It must be a positive integer.");
        }
        await _unitOfWork.CommitAsync(cancellationToken);
        return await _tripsRepository.GetPagingInfo(page, pageSize, cancellationToken);
    } 
    
    public async Task<int> AssignClientToTrip(RequestAssignClientTrip data, CancellationToken cancellationToken)
    {
        
        await _unitOfWork.InitializeAsync(cancellationToken);
        var idClient = await _clientsRepository.ClientExists(data.Pesel, cancellationToken);
        if (await _clientsRepository.IsClientAssignedToTrip(data.Pesel, data.IdTrip, cancellationToken)) throw new DomainException("Client with given pesel is already assigned to trip!");
        if (await _tripsRepository.IsTripInFutureAndExists(data.IdTrip, cancellationToken)) throw new DomainException("Trip doesn't exists or is in the past!");
        if (data.PaymentDate == null && await _tripsRepository.IsTripPaidByClient(data.IdTrip, data.Pesel, cancellationToken)) throw new DomainException("Trip is paid by client! PaymentDate can't be null!");
        await _unitOfWork.CommitAsync(cancellationToken);
        return await _clientsRepository.AssignClientToTrip(data, idClient, cancellationToken);
    }
    
}


