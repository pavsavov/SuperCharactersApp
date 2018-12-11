namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CharacterCreateViewModel : ICharacterViewModel,IMapFrom<SuperHero>, IMapFrom<SuperVillain>,
        IMapTo<SuperHero>, IMapTo<SuperVillain>
    {
        public CharacterCreateViewModel()
        {
            this.SuperPowers = new HashSet<CreateSuperPowerViewModel>();
            this.Teams = new HashSet<CreateTeamViewModel>();
        }

        [Required]
        public string CharacterType { get; set; }
        [Required]
        public int HitPoints { get; set; }
        [Required]
        [Range(1,100)]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        [Required]
        public string TeamId { get; set; }

        public ICollection<CreateSuperPowerViewModel> SuperPowers { get; set; }
        public ICollection<CreateTeamViewModel> Teams { get; set; }
    }
}
