namespace Budmar_app.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
