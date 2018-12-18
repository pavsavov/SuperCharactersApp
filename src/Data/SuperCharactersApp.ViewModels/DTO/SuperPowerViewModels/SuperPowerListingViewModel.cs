namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;
    using System.ComponentModel.DataAnnotations;

    public class SuperPowersListingViewModel :
        IReusableModalViewModel,
        IMapTo<SuperPower>,
        IMapFrom<SuperPower>
        
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name ="Name of Superpower")]
        public string SuperPowerName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Value { get; set; }
        public ModalViewModel ModalView { get; set; }
    }
}
