namespace SuperCharactersApp.ViewModels.Contracts
{
    public interface ICharacterViewModel : IReusableModalViewModel
    {
        string CharacterType { get; set; }

    }
}
