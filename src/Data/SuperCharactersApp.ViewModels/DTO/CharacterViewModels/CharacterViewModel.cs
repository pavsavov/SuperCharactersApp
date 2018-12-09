using SuperCharactersApp.Services.Account.ViewModels.Contracts;
using SuperCharactersApp.ViewModels.DTO.CharacterViewModels.Enums;
using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    public class CharacterViewModel : IViewModel
    {
        public CharacterViewModel()
        {
            this.SuperPowers = new List<CreateSuperPowerViewModel>();
        }
        [Required]
        public string CharacterType { get; set; } // will be enum
        [Required]
        public int HitPoints { get; set; }
        [Required]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Team { get; set; }
        public string SecretIdentity { get; set; }
        public ICollection<CreateSuperPowerViewModel> SuperPowers { get; set; }

    }
}
