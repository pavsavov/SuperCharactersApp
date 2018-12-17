namespace SuperCharactersApp.ViewModels.Contracts
{
    /// <summary>
    /// The following interface is implemented by the CharacterViewModels when  
    /// differentiation between Superhero and Supervillain needed.
    /// </summary>
    public interface ICharacterViewModel : IReusableModalViewModel
    {
        string CharacterType { get; set; }

    }
}
