namespace SuperCharactersApp.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.DataAccess;
    using SuperCharactersApp.Repository.Contracts;

    /// <summary>
    /// Generic Repository with IRepositoryGeneric interface implementation
    /// for perfoming CRUD operations communicating directly the Database;
    /// </summary>
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity>
        where TEntity : class
    {
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryGeneric(SuperCharactersAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._dbSet.OfType<TEntity>();
        }

        //TODO: Need to make sure unique teamname values are stored in Db.
        public virtual bool Create(TEntity entity)
        {
            var IfExists = _dbSet.Any(x => x.Equals(entity));
            if (!IfExists)
            {
                _dbSet.Add(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void DeleteById(string id)
        {
            TEntity entityToDelete = _dbSet.Find(id);

            _dbContext.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
