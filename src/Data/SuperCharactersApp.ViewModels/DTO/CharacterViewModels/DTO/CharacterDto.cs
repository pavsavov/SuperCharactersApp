using SuperCharacters.Models;
using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperCharactersApp.ViewModels.DTO.CharacterViewModels.DTO
{

    public class CharacterDto
    {
        public CharacterDto()
        {
            this.SuperPowers = new HashSet<SuperPowerViewModel>();
            this.Teams = new List<CreateTeamViewModel>();
        }
        public string Id { get; set; }
        [Required]
        public string CharacterType { get; set; }
        [Required]
        public int HitPoints { get; set; }
        [Required]
        public int Armour { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }

        public Team Team { get; set; }
        public string TeamId { get; set; }
        public ICollection<SuperPowerViewModel> SuperPowers { get; set; }
        public ICollection<CreateTeamViewModel> Teams { get; set; }

    }
}
