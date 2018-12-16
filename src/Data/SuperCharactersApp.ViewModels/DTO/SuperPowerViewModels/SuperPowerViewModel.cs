namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class SuperPowerViewModel : IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        [Required]
        [Display(Name ="Name of Superpower")]
        [StringLength(100, MinimumLength = 1)]
        public string SuperPowerName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
