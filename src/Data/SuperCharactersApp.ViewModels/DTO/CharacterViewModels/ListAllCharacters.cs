namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;
    using System.Collections.Generic;
    public class ListAllCharacters : IReusableModalViewModel
    {
        public ListAllCharacters()
        {
            this.AllCharacters = new List<CharacterViewModel>();
        }
        public ICollection<CharacterViewModel> AllCharacters { get; set; }
        public ModalViewModel ModalView { get; set;  }
    }
}
