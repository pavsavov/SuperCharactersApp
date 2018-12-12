namespace SuperCharacters.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SuperHero : Character
    {
        [Required]
        [Range(100, 200)]
        public double HitPoints { get; set; }
        //public override Score Score { get; set; }
    }
}
