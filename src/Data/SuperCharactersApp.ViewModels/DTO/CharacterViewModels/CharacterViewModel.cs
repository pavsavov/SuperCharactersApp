namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels
{
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharacters.Models;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using AutoMapper;
    using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;

    public class CharacterViewModel :
        IMapFrom<SuperHero>,
        IMapTo<SuperHero>,
        IHaveCustomMappings,
        IMapTo<SuperVillain>

    {
        public CharacterViewModel()
        {

            //SuperPowerId = new HashSet<string>();
            SuperPowers = new HashSet<SuperPowersListingViewModel>();
            Teams = new HashSet<TeamViewModel>();
        }
        public string Id { get; set; }
        [Required]
        [Display(Name = "Character type")]
        public string CharacterType { get; set; }
        [Required]
        [Range(100, 200)]
        [Display(Name = "Hitpoints")]
        public double HitPoints { get; set; }
        [Required]
        [Range(0, 100)]
        public int Armour { get; set; }
        [Required]
        [Range(10, 50)]
        public int Damage { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        public SecretIdentityViewModel SecretIdentity { get; set; }
        public Team Team { get; set; }
        [Required]
        [Display(Name = "Select team")]
        public string TeamId { get; set; }
        public ICollection<string> SuperPowerId { get; set; }
        public ICollection<SuperPowersListingViewModel> SuperPowers { get; set; }
        public ICollection<TeamViewModel> Teams { get; set; }
        public ModalViewModel ModalView { get; set; }

        /// <summary>
        /// Custom mapping which performs casting of Characters into SuperVillain or SuperHero 
        /// in order Automapper to correctly map int to int and double to double.
        /// </summary>
        /// <param name="configuration"></param>

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration
                .CreateMap<Character, CharacterViewModel>()
                .ForMember(cvm => cvm.HitPoints, cvm => cvm.MapFrom(x =>
                                                    x is SuperVillain
                                                    ? (double)((SuperVillain)x).HitPoints
                                                    : (x is SuperHero
                                                       ? ((SuperHero)x).HitPoints
                                                       : 0D)));


        }
    }
}
