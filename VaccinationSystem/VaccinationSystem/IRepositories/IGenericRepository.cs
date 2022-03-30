namespace VaccinationSystem.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
