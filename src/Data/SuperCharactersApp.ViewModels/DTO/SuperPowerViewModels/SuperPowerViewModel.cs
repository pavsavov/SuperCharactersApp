namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class SuperPowerViewModel : IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
