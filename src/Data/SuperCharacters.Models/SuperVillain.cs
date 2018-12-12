namespace SuperCharacters.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SuperVillain : Character
    {

        [Required]
        [Range(100, 200)]
        public int HitPoints { get; set; }
        //public override Score Score { get; set; }
    }
}
