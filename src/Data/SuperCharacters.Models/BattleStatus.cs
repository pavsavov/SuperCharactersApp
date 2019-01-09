using System.ComponentModel.DataAnnotations;

namespace SuperCharacters.Models
{
    public class BattleStatus
    {
        public string Id { get; set; }

        [Display(Name = "In progress")]
        public string InProgress { get; set; }
        public string Completed { get; set; }
        public virtual Battle Battle { get; set; }
    }
}
