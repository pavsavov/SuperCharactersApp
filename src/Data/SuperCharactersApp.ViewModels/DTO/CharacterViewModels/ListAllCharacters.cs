namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using System.Collections.Generic;
    public class ListAllCharacters
    {
        public ListAllCharacters()
        {
            this.AllCharacters = new List<CharacterViewModel>();
        }
        public ICollection<CharacterViewModel> AllCharacters { get; set; }
    }
}
