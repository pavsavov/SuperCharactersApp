namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{

    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharacters.Models;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;

    public class CharacterViewModel : ICharacterViewModel, IMapFrom<SuperHero>, IMapTo<SuperHero>,
        IMapFrom<SuperVillain>, IMapTo<SuperVillain>

    {

        public CharacterViewModel()
        {
            this.SuperPowers = new HashSet<SuperPowersListingViewModel>();
            this.Teams = new List<CreateTeamViewModel>();
        }
        public string Id { get; set; }
        [Required]
        public string CharacterType { get; set; }
        [Required]
        public double HitPoints { get; set; }
        [Required]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        [Required]
        public Team Team { get; set; }
        public string TeamId { get; set; }
        public ICollection<SuperPowersListingViewModel> SuperPowers { get; set; }
        public ICollection<CreateTeamViewModel> Teams { get; set; }

    }
}
