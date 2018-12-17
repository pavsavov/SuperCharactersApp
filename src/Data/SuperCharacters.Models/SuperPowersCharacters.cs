using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCharacters.Models
{
    public class SuperPowersCharacters
    {
        public string CharacterId { get; set; }
        public Character Character { get; set; }

        public string SuperPowerId { get; set; }
        public SuperPower SuperPower { get; set; } 
    }
}
