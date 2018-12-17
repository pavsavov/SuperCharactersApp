namespace SuperCharactersApp.ViewModels.Contracts
{
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;
    /// <summary>
    /// Interface implemented by the ModalViewModel.
    /// </summary>
    public interface IReusableModalViewModel
    {
        ModalViewModel ModalView { get; set; }
    }
}
