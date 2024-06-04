using WebApplication1.Data;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task InitializeAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    ScaffoldContext Context { get;  }
}