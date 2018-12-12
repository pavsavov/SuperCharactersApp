namespace SuperCharacters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class SuperPower
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public double Value { get; set; }
    }
}
