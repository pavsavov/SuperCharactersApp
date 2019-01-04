
namespace SuperCharactersApp.ViewModels.DTO.PartialViewsViewModels
{
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System.Collections.Generic;
    public class EditCharacterSuperpowersPartialViewModel
    {
        public EditCharacterSuperpowersPartialViewModel()
        {
            CurrentCharacterSuperpowers = new HashSet<SuperPowersListingViewModel>();
            AllSuperPowers = new HashSet<SuperPowersListingViewModel>();
        }
        public ICollection<SuperPowersListingViewModel> CurrentCharacterSuperpowers { get; set; }
        public ICollection<SuperPowersListingViewModel> AllSuperPowers { get; set; }
    }
}
