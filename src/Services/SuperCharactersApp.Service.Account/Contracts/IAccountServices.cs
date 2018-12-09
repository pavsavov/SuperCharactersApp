namespace SuperCharactersApp.Services.Account.Contracts
{
    using SuperCharacters.Models;
    using SuperCharactersApp.Services.Account.ViewModels.Contracts;

    public interface IAccountServices
    {
        IViewModel GetById(string id);
        void Create(SuperCharactersUser user);
        void Update(SuperCharactersUser userToUpdate);
        void DeleteById(string id);
    }
}
