namespace SuperCharacters.Web.ViewModels.Account
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using SuperCharactersApp.Services.Account.ViewModels.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class LoginBindingModel 
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
