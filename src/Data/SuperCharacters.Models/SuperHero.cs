namespace SuperCharacters.Models
{
    using SuperCharacters.Models.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class SuperHero : Character, ICharacter<double>
    {
        [Required]
        [Range(100, 200)]
        public double HitPoints { get; set; }
        //public override Score Score { get; set; }
    }
}
