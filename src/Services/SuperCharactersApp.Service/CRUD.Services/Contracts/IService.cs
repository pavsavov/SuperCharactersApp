namespace SuperCharactersApp.Services.CRUD.Services.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Generic interface with all needed methods used for CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T model);
        void Edit(T modelToUpdate);
        bool DeleteById(string id);
    }
}
