namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Models.Enums;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class SuperPowersListingViewModel : IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
    }
}
