using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Data;
using WebApplication1.Exceptions;

namespace WebApplication1.Repositories;
// TODO implement UnitOfWork
public class UnitOfWork : IUnitOfWork
{
    private readonly ScaffoldContext _context;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(ScaffoldContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (await _context.Database.CanConnectAsync(cancellationToken))
                _transaction =  await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            if (_transaction == null)
            {
                throw new NotInitalizedException();
            }
        
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public ScaffoldContext Context => _context;


        public async void Dispose()
        {
            await _context.DisposeAsync();
            if (_transaction != null) await _transaction.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            if (_transaction == null) return;
            await _transaction.DisposeAsync();
            GC.SuppressFinalize(this);
        }

    }
