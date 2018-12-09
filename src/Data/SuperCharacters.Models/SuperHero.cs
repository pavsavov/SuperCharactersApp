using SuperCharacters.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperCharacters.Models
{
    public class SuperHero : Character, ICharacter<double>
    {
        [Required]
        [Range(100,200)]
        public double HitPoints { get; set; }
        //public override Score Score { get; set; }
    }
}
