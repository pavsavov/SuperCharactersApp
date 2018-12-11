namespace SuperCharacters.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Base model used in DataBase. 
    /// Using EF Core Discriminator which implements table-per-hierarchy (TPH) pattern, 
    /// the ORM will automatically load data for Superhero or Supervillain.
    /// Both entities,Superhero and Supervillain inherit it.
    /// </summary>
    public class Character
    {
        private const int MaxSuperPowersPerCharacter = 3;
        public Character()
        {
            this.SuperPowers = new List<SuperPower>(MaxSuperPowersPerCharacter);
        }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [Range(0, 100)]
        public int Armour { get; set; }
        [Required]
        [Range(10, 50)]
        public int Damage { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [ForeignKey("Team")]
        public string TeamId { get; set; }
        [Required]
        public virtual Team Team { get; set; }
        public virtual ICollection<SuperPower> SuperPowers { get; set; }
        public Score Score { get; set; }

        //mapped discriminator to actual CLR property.
        public string CharacterType { get; set; }
    }
}
