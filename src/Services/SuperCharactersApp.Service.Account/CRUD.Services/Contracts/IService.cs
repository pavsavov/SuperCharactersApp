namespace SuperCharactersApp.Services.Account.Contracts
{
    using SuperCharacters.Models;
    using SuperCharactersApp.Services.Account.ViewModels.Contracts;

    public interface IService<T>
    {
        IViewModel GetById(string id);
        void Create(T user);
        void Update(T userToUpdate);
        void DeleteById(string id);
    }
}
