namespace SuperCharactersApp.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.DataAccess;
    using SuperCharactersApp.Repository.Account.Contracts;

    /// <summary>
    /// Generic Repository with IRepositoryGeneric interface implementation
    /// for perfoming CRUD operations within Database;
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity>
        where TEntity : class
    {
        internal SuperCharactersAppDbContext dbContext;
        internal DbSet<TEntity> dbSet;

        public RepositoryGeneric(SuperCharactersAppDbContext dbContext )
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;  
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void DeleteById(string id)
        {
            TEntity entityToDelete = dbSet.Find(id);

            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual TEntity GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
