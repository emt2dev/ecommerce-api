using api.DAL.Interfaces;
using api.DAL.Models.DTOs.Pagination;
using Microsoft.EntityFrameworkCore;
using static api.DAL.Interfaces.IUnitOfWork;

namespace api.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataBaseContext _context;
        private bool _disposed;
        private bool disposed = false;

        public UnitOfWork(DataBaseContext context)
        {
            this._context = context;
        }
        public void Commit()
        {
            _context.SaveChangesAsync();
        }

        public void CommitNoAsync()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) _context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            private readonly DataBaseContext _context;

            public GenericRepository(DataBaseContext context)
            {
                this._context = context;
            }

            public async Task<T> AddAsync(T entity)
            {
                _ = await _context.AddAsync(entity);
                return entity;
            }

            public async Task DeleteAsync(int Id)
            {
                var entityToDelete = await GetByAsyncId(Id);
                _ = _context.Set<T>().Remove(entityToDelete);
            }

            public async Task<PagedResult<T>> GetAllAsyncPaged<TResult>(PagedQuery PQ)
            {
                var recordCount = await _context.Set<T>().CountAsync();
                var records = await _context.Set<T>()
                    .Skip(PQ.PageNumber)
                    .Take(PQ.PageSize)
                    .ToListAsync();

                return new PagedResult<T>
                {
                    Records = records,
                    PageNumber = PQ.PageNumber,
                    TotalCount = recordCount
                };
            }

            public async Task<T> GetByAsyncId(int id)
            {
                if (id <= 0) return null;

                return await _context.Set<T>()
                    .FindAsync(id);
            }

            public async Task<bool> RowExists(int Id)
            {
                var EntitySearchingFor = await GetByAsyncId(Id);
                return EntitySearchingFor != null;
            }

            public async void Update(T entity)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }

            /*
            * intentionally left blank
            */

        }
    }
}
