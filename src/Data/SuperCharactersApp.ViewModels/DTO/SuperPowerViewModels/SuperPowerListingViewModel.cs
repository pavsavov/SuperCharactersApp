namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.ViewModels.Contracts;
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;

    public class SuperPowersListingViewModel :IReusableModalViewModel, IMapTo<SuperPower>, IMapFrom<SuperPower>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public ModalViewModel ModalView { get; set; }
    }
}
