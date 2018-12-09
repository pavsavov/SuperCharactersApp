using SuperCharacters.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperCharacters.Models
{
    public class SuperVillain : Character, ICharacter<int>
    {

        [Required]
        [Range(100,200)]
        public int HitPoints { get; set; }
        //public override Score Score { get; set; }
    }
}
