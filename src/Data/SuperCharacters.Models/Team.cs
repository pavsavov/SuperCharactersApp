using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SuperCharacters.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamMembers = new List<Character>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        public Score Score { get; set; }
        public virtual ICollection<Character> TeamMembers { get; set; }
    }
}
