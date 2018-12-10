namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using System.Collections.Generic;
    public class List
    {
        public List()
        {
            this.AllCharacters = new List<CharacterViewModel>();
        }
        public ICollection<CharacterViewModel> AllCharacters { get; set; }
    }
}
