namespace SuperCharactersApp.ViewModels.DTO.TeamViewModels
{
    using CharacterViewModels;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.ViewModels.Contracts;
    using System.Collections.Generic;
    public class CreateTeamViewModel : IMapFrom<Team>,IMapTo<Team>,IViewModel
    {
        public string Name { get; set; }
        //public ICollection<CharacterViewModel> TeamMembers { get; set; }

    }
}
