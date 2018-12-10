namespace SuperCharactersApp.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.DataAccess;


    /// <summary>
    /// Generic Repository with IRepositoryGeneric interface implementation
    /// for perfoming CRUD operations within Database;
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryGeneric<TEntity> : Account.Contracts.IRepositoryGeneric<TEntity>
        where TEntity : class
    {
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryGeneric(SuperCharactersAppDbContext dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._dbSet;  
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);

        }

        public virtual void DeleteById(string id)
        {
            TEntity entityToDelete = _dbSet.Find(id);

            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
