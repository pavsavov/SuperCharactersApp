namespace SuperCharactersApp.Services.Account.Contracts
{
    using SuperCharacters.Models;
    public interface IAccountServices
    {
        SuperCharactersUser GetById(string id);
        void Create(SuperCharactersUser user);
        void Update(SuperCharactersUser userToUpdate);
        void DeleteById(string id);
    }
}
