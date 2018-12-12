namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    public class SuperPowersListingViewModel : IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
    }
}
