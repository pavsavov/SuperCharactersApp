namespace SuperCharacters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// DataModel for keeping the Scores of all three entities - Character(Supervillain or Superhero),Team and Player(user)
    /// </summary>
    public class Score
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Wins { get; set; }
        public int Loses { get; set; }
        [ForeignKey("CharacterScore")]
        public string CharacterScoreId { get; set; }
        public virtual Character CharacterScore { get; set; }
        [ForeignKey("TeamScore")]
        public string TeamScoreId { get; set; }
        public virtual Team TeamScore { get; set; }
        [ForeignKey("PlayerScore")]
        public string PlayerScoreId { get; set; }
        public virtual SuperCharactersUser PlayerScore { get; set; }
    }
}
