using api.DAL.Models.DTOs.Pagination;

namespace api.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public void Commit();
        public void Rollback();

        public interface IGenericRepository<T> where T : class
        {
            public Task<T> AddAsync(T entity);

            public Task DeleteAsync(int Id);

            public Task<PagedResult<T>> GetAllAsyncPaged<TResult>(PagedQuery PQ);

            public Task<T> GetByAsyncId(int id);

            public Task<bool> RowExists(int Id);

            public void Update(T entity);
        }
    }
}
