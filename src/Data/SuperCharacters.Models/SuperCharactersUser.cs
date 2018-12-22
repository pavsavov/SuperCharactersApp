namespace SuperCharacters.Models
{
    using Microsoft.AspNetCore.Identity;
    public class SuperCharactersUser : IdentityUser
    {
        public Score Score { get; set; }
    }
}
