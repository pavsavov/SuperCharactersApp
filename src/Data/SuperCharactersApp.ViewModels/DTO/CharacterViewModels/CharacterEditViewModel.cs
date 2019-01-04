using SuperCharactersApp.ViewModels.DTO.PartialViewsViewModels;
using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
using System.Collections.Generic;

namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    public class CharacterEditViewModel
    {
        public CharacterEditViewModel()
        {
            AllSuperpowers = new HashSet<SuperPowersListingViewModel>();
        }
        public CharacterViewModel CurrentCharacter { get; set; }
        public ICollection<SuperPowersListingViewModel> AllSuperpowers { get; set; }
    }
}
