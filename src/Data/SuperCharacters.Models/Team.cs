using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SuperCharacters.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamMembers = new HashSet<Character>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string TeamName { get; set; }
        public Score Score { get; set; }
        public virtual ICollection<Character> TeamMembers { get; set; }
    }
}
