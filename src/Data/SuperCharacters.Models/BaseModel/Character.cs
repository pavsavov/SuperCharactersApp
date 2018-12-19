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
        //Metadata purpose
        private const int MaxSuperPowersPerCharacter = 3;
        public Character()
        {
            SuperPowersCharacters = new HashSet<SuperPowersCharacters>(MaxSuperPowersPerCharacter);
        }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Armour { get; set; }

        public int Damage { get; set; }

        public string Name { get; set; }
        [ForeignKey("Team")]
        public string TeamId { get; set; }
        public virtual Team Team { get; set; }
        //[ForeignKey("SecretIdentity")]
        //public string SecretIdentityId { get; set; }
        public virtual SecretIdentity SecretIdentity { get; set; }
        public virtual ICollection<SuperPowersCharacters> SuperPowersCharacters { get; set; }
        public Score Score { get; set; }

        //mapped discriminator to actual CLR property.
        public string CharacterType { get; set; }
    }
}
