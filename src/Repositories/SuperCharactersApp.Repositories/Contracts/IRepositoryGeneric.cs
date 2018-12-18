namespace SuperCharactersApp.Repository.Account.Contracts
{
    using System.Linq;

    /// <summary>
    /// Interface Implemented by the RepositoryGeneric class.
    /// The following methods are all needed for the CRUD operations perfored in the repository layer.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryGeneric<TEntity>
        where TEntity : class
    {
        TEntity GetById(string id);
        void Create(TEntity entity);
        void Edit(TEntity entityToEdit);
        void DeleteById(string id);
        IQueryable<TEntity> GetAll();
    }
}
