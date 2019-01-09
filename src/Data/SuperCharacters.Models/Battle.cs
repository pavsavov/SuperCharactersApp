using System.ComponentModel.DataAnnotations;
using SuperCharacters.Models;

namespace SuperCharacters.Models
{
    public class Battle
    {
        [Key]
        public string Id { get; set; }
        public Character SuperHero { get; set; }
        public Character SuperVillain { get; set; }
        public string StatusId { get; set; }
        public BattleStatus Status { get; set; }
        public Character Winner { get; set; }
    }
}
