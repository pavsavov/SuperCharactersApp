namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CharacterCreateViewModel : ICharacterViewModel,IMapFrom<SuperHero>, IMapFrom<SuperVillain>,
        IMapTo<SuperHero>, IMapTo<SuperVillain>
    {
        public CharacterCreateViewModel()
        {
            this.SuperPowers = new HashSet<SuperPowerViewModel>();
            this.Teams = new HashSet<CreateTeamViewModel>();
        }

        [Required]
        public string CharacterType { get; set; }
        [Required]
        public double HitPoints { get; set; }
        [Required]
        [Range(1,100)]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        public SecretIdentityViewModel SecretIdentity { get; set; }
        [Required]
        public string TeamId { get; set; }

        public ICollection<SuperPowerViewModel> SuperPowers { get; set; }
        public ICollection<CreateTeamViewModel> Teams { get; set; }
    }
}
