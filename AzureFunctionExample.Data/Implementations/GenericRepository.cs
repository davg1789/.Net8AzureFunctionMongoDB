using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Domain.Extensions;
using AzureFunctionExample.Domain.Services.Interfaces;
using MongoDB.Driver;

namespace AzureFunctionExample.Data.MongoDB.Implementations
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IMongoContext context;

        protected GenericRepository(
            IMongoContext context)
        {
            this.context = context;
        }

        protected abstract string CollectionName { get; }

        protected IMongoCollection<TEntity> DbSet => this.GetCollection();

        public virtual void Add(TEntity obj)
        {
            if (obj.IsNull())
            {
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null");
            }

            this.DbSet.InsertOne(obj);
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            if (obj.IsNull())
            {
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null");
            }

            await this.DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.DbSet.AsQueryable().ToListAsync();
        }

        private IMongoCollection<TEntity> GetCollection()
        {
            return this.context.GetCollection<TEntity>(this.GetCollectionName());
        }

        private string GetCollectionName()
        {
            return !string.IsNullOrWhiteSpace(this.CollectionName)
                ? this.CollectionName
                : typeof(TEntity).Name;
        }
    }
}
