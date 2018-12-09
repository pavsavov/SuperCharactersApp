using SuperCharacters.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperCharacters.Models
{
    public class SuperPower
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(100,MinimumLength =1)]
        public string Name { get; set; }
        [Required]
        public SuperPowerType Type { get; set; }
        public double Value { get; set; }
    }
}
