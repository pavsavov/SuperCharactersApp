namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Models.Enums;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class CreateSuperPowerViewModel : IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public SuperPowerType Type { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
