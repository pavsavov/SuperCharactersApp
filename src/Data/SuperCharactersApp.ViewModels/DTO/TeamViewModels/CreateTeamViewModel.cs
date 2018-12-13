namespace SuperCharactersApp.ViewModels.DTO.TeamViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class CreateTeamViewModel : IMapFrom<Team>,IMapTo<Team>
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
