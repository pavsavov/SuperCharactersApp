using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SuperCharacters.Models
{
    public class SuperCharacterUser : IdentityUser
    {
        public  Score Score { get; set; }
    }
}
