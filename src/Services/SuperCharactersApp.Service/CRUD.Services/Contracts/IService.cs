using System.Collections.Generic;


namespace SuperCharactersApp.Services.CRUD.Services.Contracts
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T model);
        void Update(T modelToUpdate);
        bool DeleteById(string id);
    }
}
