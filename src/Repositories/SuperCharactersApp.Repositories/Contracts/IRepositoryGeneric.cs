namespace SuperCharactersApp.Repository.Account.Contracts
{
    using System.Linq;
    public interface IRepositoryGeneric<TEntity>
        where TEntity : class
    {
        TEntity GetById(string id);
        void Create(TEntity entity);
        void Update(TEntity entityToUpdate);
        void DeleteById(string id);
        IQueryable<TEntity> GetAll();
    }
}
