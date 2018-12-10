namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{

    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharacters.Models;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;

    public class CharacterViewModel : IMapFrom<Character>, IMapTo<Character>, IViewModel
    {

        public CharacterViewModel()
        {
            this.SuperPowers = new HashSet<CreateSuperPowerViewModel>();
            this.Teams = new List<CreateTeamViewModel>();
        }
        [Required]
        public string CharacterType { get; set; }
        [Required]
        public int HitPoints { get; set; }
        [Required]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        [Required]
        public Team Team { get; set; }
        public ICollection<CreateSuperPowerViewModel> SuperPowers { get; set; }
        public ICollection<CreateTeamViewModel> Teams { get; set; }

    }
}
