namespace SuperCharactersApp.Repository.Contracts
{
    using SuperCharacters.Models;

    /// <summary>
    /// The following interface describes all the properties,
    /// that implements the generic repository
    /// </summary>
    public interface IUnitOfWork
    {
        RepositoryGeneric<Character> CharacterRepository { get; }
        RepositoryGeneric<Team> TeamRepository { get; }
        RepositoryGeneric<SuperPower> SuperPowerRepository { get; }
        RepositoryGeneric<SecretIdentity> SecretIdentityRepository { get; }
     //   RepositoryGeneric<Battle> BattleRepository { get; }
        void Save();
    }
}
