namespace SuperCharactersApp.ViewModels.DTO.TeamViewModels
{
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using System.Collections.Generic;
    public class CreateTeamViewModel
    {
        public string Name { get; set; }
        public ICollection<CharacterViewModel> TeamMembers { get; set; }

    }
}
