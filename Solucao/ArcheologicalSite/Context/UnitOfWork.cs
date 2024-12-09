using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ArcheologicalSite.Context
{
    public class AppUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private DbTransaction? _currentTransaction;

        public AppUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction is null)
            {
                var dbConnection = _context.Database.GetDbConnection();
                if (dbConnection.State == System.Data.ConnectionState.Closed)
                {
                    await dbConnection.OpenAsync();
                }

                _currentTransaction = await dbConnection.BeginTransactionAsync();
                await _context.Database.UseTransactionAsync(_currentTransaction);
            }
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_currentTransaction is not null)
                {
                    await _context.SaveChangesAsync();
                    await _currentTransaction.CommitAsync();
                }
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction is not null)
                {
                    await _currentTransaction.RollbackAsync();
                }
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task DisposeTransactionAsync()
        {
            if (_currentTransaction is not null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }
}