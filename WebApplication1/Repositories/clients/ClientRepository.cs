using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.clients;

public class ClientRepository : BaseRepository, IClientsRepository
{
    
    // TODO ogarnac kodzik do delete
    public Task<bool> ClientHasTrip(int idClient)
    {
        throw new NotImplementedException();
    }

    public Task<ClientDTO> DeleteClient(int idClient)
    {
        throw new NotImplementedException();
    }

    public ClientRepository(ScaffoldContext context) : base(context)
    {
    }
}