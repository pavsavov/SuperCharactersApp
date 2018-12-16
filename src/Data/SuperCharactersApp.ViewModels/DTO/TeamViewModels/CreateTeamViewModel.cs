namespace SuperCharactersApp.ViewModels.DTO.TeamViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class CreateTeamViewModel :
        IMapFrom<Team>,
        IMapTo<Team>
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name ="Team name")]
        public string TeamName { get; set; }

    }
}
