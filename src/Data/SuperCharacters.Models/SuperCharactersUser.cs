using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SuperCharacters.Models
{
    public class SuperCharactersUser : IdentityUser
    {
        public  Score Score { get; set; }
    }
}
