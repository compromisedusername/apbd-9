using WebApplication1.Data;

namespace WebApplication1.Repositories;

public class BaseRepository
{
    protected readonly ScaffoldContext _context;

    public BaseRepository(ScaffoldContext context)
    {
        _context = context;
    }
}