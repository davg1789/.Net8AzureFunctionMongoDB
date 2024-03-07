namespace AzureFunctionExample.Domain.Services.Interfaces
{
    public interface IRepository<TEntity>
         where TEntity : class
    {
        void Add(TEntity obj);

        Task AddAsync(TEntity obj);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
